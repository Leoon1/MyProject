using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Server.Models;
using MyProject.Server.ViewModels;


namespace MyProject.Server.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment appEnvironment;

        public UsersController(UserManager<User> userManager, IWebHostEnvironment appEnvironment)
        {
            this.userManager = userManager;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Index() => View(userManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronymic = model.Patronymic,
                    UserName = model.Email,
                    Age = model.Age
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Age = user.Age,
                PathAvatar = user.PathAvatar,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile uploadedFile, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Patronymic = model.Patronymic;
                    user.Email = model.Email;
                    user.Age = model.Age;

                    if (uploadedFile != null)
                    {
                        if (Path.GetExtension(uploadedFile.FileName).ToUpper() != ".JPG")
                        {
                            ModelState.AddModelError(string.Empty, "Формат файла не соответствует, загружаем только .jpg");
                            return View(model);
                        }
                        if (uploadedFile.Length > 2097152)
                        {
                            ModelState.AddModelError(string.Empty, "Файл должен быть не больше 2 мегабайт");
                            return View(model);
                        }

                        var path = @"\Files\" + uploadedFile.FileName;
                        await using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        user.PathAvatar = path;
                    }

                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var result =
                        await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        foreach (var error in result.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                }
                else
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }






                //FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                //_context.Files.Add(file);
                //_context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #region Old, изменение пароля на прямую

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(OldChangePasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await userManager.FindByIdAsync(model.Id);
        //        if (user != null)
        //        {
        //            var passwordValidator =
        //                HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
        //            var passwordHasher =
        //                HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

        //            var result =
        //                await passwordValidator.ValidateAsync(userManager, user, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
        //                await userManager.UpdateAsync(user);
        //                return RedirectToAction("Index");
        //            }
        //            else
        //                foreach (var error in result.Errors)
        //                    ModelState.AddModelError(string.Empty, error.Description);

        //        }
        //        else
        //            ModelState.AddModelError(string.Empty, "Пользователь не найден");
        //    }
        //    return View(model);
        //}

        #endregion
    }
}

