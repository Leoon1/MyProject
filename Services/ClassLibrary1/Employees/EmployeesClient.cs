using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyProject.Clients.Base;
using MyProject.Domain.Models;
using MyProject.Interfaces.API;

namespace MyProject.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeeServices
    {
        public EmployeesClient(IConfiguration configuration): base(configuration, "api/employees") { }

        public IEnumerable<Employee> Get()
        {
            var response = Http.GetAsync(Address).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
            return Enumerable.Empty<Employee>();
        }

        public Employee Get(int id)
        {
            var response = Http.GetAsync($"{Address}/{id}").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Employee>().Result;
            return new Employee();
        }

        public Uri Post(string value)
        {
            var response = Http.PostAsJsonAsync(Address, value).Result;
            return response.EnsureSuccessStatusCode().Headers.Location;
        }

        public HttpStatusCode Update(int id, string value)
        {
            var response = Http.PostAsJsonAsync($"{Address}/{id}", value).Result;
            return response.EnsureSuccessStatusCode().StatusCode;
        }

        public HttpStatusCode Delete(int id)
        {
            var response = Http.DeleteAsync($"{Address}/{id}").Result;
            return response.StatusCode;
        }

    }
}
