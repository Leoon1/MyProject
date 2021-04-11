using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DAL.Context;
using MyProject.Domain.Models;
using MyProject.Interfaces.Services;

namespace MyProject.Servises.Employees
{
    public class MySqlEmployeesData : IEmployeesData
    {
        private readonly MyProjectDB _myProjectDb;

        public MySqlEmployeesData(MyProjectDB myProjectDb)
        {
            _myProjectDb = myProjectDb;
        }

        public IEnumerable<Employee> Get()
        {
            var eml = _myProjectDb.Employees.ToList();
            return eml;
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Employee employee)
        {
            _myProjectDb.Add(employee);
            var number = _myProjectDb.SaveChanges();
            
            return number;
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var employee = _myProjectDb.Employees.FirstOrDefault(emp => emp.Id == id);
            _myProjectDb.Employees.Remove(employee);
            var resp = _myProjectDb.SaveChanges();

            return resp == 1;
        }
    }
}
