﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyProject.Clients.Base;
using MyProject.Interfaces.Services;
using Microsoft.Extensions.Logging;
using MyProject.Domain.Entities;
using MyProject.Interfaces;

namespace MyProject.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        private readonly ILogger<EmployeesClient> _Logger;

        public EmployeesClient(IConfiguration Configuration, ILogger<EmployeesClient> Logger)
            : base(Configuration, WebAPI.Employees) =>
            _Logger = Logger;


        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(Address);

        public Employee Get(int id) => Get<Employee>($"{Address}/{id}");

        public int Add(Employee employee) => Post(Address, employee).Content.ReadAsAsync<int>().Result;

        public void Update(Employee employee)
        {
            _Logger.LogInformation("Редактирование сотрудника с id:{0}", employee.Id);
            Put(Address, employee);
        }

        public bool Delete(int id) => Delete($"{Address}/{id}").IsSuccessStatusCode;
        
    }
}
