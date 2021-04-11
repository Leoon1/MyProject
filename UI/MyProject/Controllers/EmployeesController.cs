using System;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Models;
using MyProject.Domain.ViewModels;
using MyProject.Interfaces.Services;

namespace MyProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeeServices;

        public EmployeesController(IEmployeesData Employees) => _employeeServices = Employees;

        public IActionResult Index()
        {
            var employees = _employeeServices.Get();
            return View(employees);
        }

        //public IActionResult Details(int id)
        //{
        //    var employee = _employeeServices.Get(id);
        //    if (employee is not null)
        //        return View(employee);

        //    return NotFound();
        //}

        public IActionResult Create() => View("Edit");

        #region Edit

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeesViewModel());

            if (id < 0)
                return BadRequest();

            var employee = _employeeServices.Get((int)id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployeesViewModel Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            var employee = new Employee
            {
                Id = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.FirstName,
                Patronymic = Model.Patronymic,
                Age = Model.Age,
            };

            if (employee.Id == 0)
                _employeeServices.Add(employee);
            else
                _employeeServices.Update(employee);

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _employeeServices.Get(id);
            if (employee is null)
                return NotFound();

            return View(new Employee
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeServices.Delete(id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
