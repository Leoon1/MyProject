using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Interfaces.API;

namespace MyProject.Controllers
{
    public class WebAPIController : Controller
    {
        private readonly IEmployeeServices _employeeServices;

        public WebAPIController(IEmployeeServices employeeServices) => _employeeServices = employeeServices;

        public IActionResult Index()
        {
            var values = _employeeServices.Get();
            return View(values);
        }
    }
}
