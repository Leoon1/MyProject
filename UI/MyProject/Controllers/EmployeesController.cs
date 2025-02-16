﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Entities;
using MyProject.Domain.ViewModels;
using MyProject.Interfaces.Services;

namespace MyProject.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData EmployeeServices;

        public EmployeesController(IEmployeesData employees) => EmployeeServices = employees;

        public IActionResult Index()
        {
            var employees = EmployeeServices.Get();
            return View(employees);
        }

        //public IActionResult Details(int id)
        //{
        //    var employee = _employeeServices.Get(id);
        //    if (employee is not null)
        //        return View(employee);

        //    return NotFound();
        //}

        public IActionResult Create()
        {
            return View("Edit", new EmployeesViewModel()
#if DEBUG
                {
                    FirstName = "Артур", 
                    LastName = "Гайнудинов", 
                    Patronymic = "Артурович", 
                    Age = 45, Email = "eb@eb.eb"
                }
#endif
                );
        }

        #region Edit

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeesViewModel());

            if (id < 0)
                return BadRequest();

            var employee = EmployeeServices.Get((int)id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Email = employee.Email,
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployeesViewModel model)
        {
            if (model.LastName == "Иванов" && model.Age == 30)
                ModelState.AddModelError("", "Странный человек...");

            if (!ModelState.IsValid) return View(model);

            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var employee = new Employee
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                Age = model.Age,
                Email = model.Email,
            };

            if (employee.Id == 0)
                EmployeeServices.Add(employee);
            else
                EmployeeServices.Update(employee);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = EmployeeServices.Get(id);
            if (employee is null)
                return NotFound();

            return View(new Employee
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Email = employee.Email,
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            EmployeeServices.Delete(id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
