using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Interfaces.Services;


namespace MyProject.Controllers
{
    public class WebAPIController : Controller
    {
        private readonly IEmployeesData _employeeServices;

        public WebAPIController(IEmployeesData employeeServices) => _employeeServices = employeeServices;

        public IActionResult Index()
        {
            var values = _employeeServices.Get();
            return View(values);
        }
    }
}
