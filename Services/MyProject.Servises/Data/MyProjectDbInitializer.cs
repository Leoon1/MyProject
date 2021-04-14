using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.DAL.Context;
using MyProject.Domain.Entities.Identity;

namespace MyProject.Servises.Data
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    public class MyProjectDbInitializer
    {
        private readonly MyProjectDB db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<MyProjectDbInitializer> logger;

        public MyProjectDbInitializer(
            MyProjectDB db,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILogger<MyProjectDbInitializer> logger)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        /// <summary>
        /// Инициализация БД миграцией, если есть миграции, не выполненные у клиента
        /// </summary>
        public void Initialize()
        {
            this.logger.LogInformation("Инициализация БД...");

            var db = this.db.Database;

            if (db.GetPendingMigrations().Any())
            {
                this.logger.LogInformation("Есть непримененные миграции...");
                db.Migrate();
                this.logger.LogInformation("Миграции БД выполнены успешно");
            }
            else
                this.logger.LogInformation("Структура БД в актуальном состоянии.");

            try
            {
                InitializeEmployees();
            }
            catch (Exception e)
            {
                this.logger.LogInformation("Ошибка при инициализации БД данными таблиц");
                throw;
            }

            try
            {
                InitializerIndentityAsync().Wait();
            }
            catch (Exception e)
            {
                this.logger.LogInformation("Ошибка при инициализации БД системы Indentity");
                throw;
            }

        }
        /// <summary>
        /// Инициализация Employees базовыми данными
        /// </summary>
        private void InitializeEmployees()
        {
            if(db.Employees.Any())
                return;

            using (db.Database.BeginTransaction())
            {
                db.Employees.AddRange(TestData.Employees);

                db.SaveChanges();
                db.Database.CommitTransaction();
            }
        }

        private async Task InitializerIndentityAsync()
        {
            async Task CheckRole(string roleName)
            {
                if (!await this.roleManager.RoleExistsAsync(roleName))
                    await this.roleManager.CreateAsync(new Role {Name = roleName});
            }

            await CheckRole(Role.Administrator);
            await CheckRole(Role.User);

            if (await this.userManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator
                };
                var creationResult = await this.userManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (creationResult.Succeeded)
                    await this.userManager.AddToRoleAsync(admin, Role.Administrator);
                else
                {
                    var errors = creationResult.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Ошибка при создании учётно записи администратора {string.Join(",", errors)}");
                }
            }
        }
    }
}
