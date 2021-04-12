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
    /// <summary>
    /// Класс для работы с БД Employees
    /// </summary>
    public class MySqlEmployeesData : IEmployeesData
    {
        private readonly MyProjectDB _myProjectDb;

        public MySqlEmployeesData(MyProjectDB myProjectDb)
        {
            _myProjectDb = myProjectDb;
        }

        /// <summary>
        /// Получение всех данных из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> Get()
        {
            var eml = _myProjectDb.Employees.ToList();
            return eml;
        }

        /// <summary>
        /// Получение определенного Employee из БД по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавление в БД
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int Add(Employee employee)
        {
            _myProjectDb.Add(employee);
            var number = _myProjectDb.SaveChanges();
            
            return number;
        }

        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="employee"></param>
        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var employee = _myProjectDb.Employees.FirstOrDefault(emp => emp.Id == id);
            _myProjectDb.Employees.Remove(employee);
            _myProjectDb.SaveChanges();
            var nonEmp = _myProjectDb.Employees.FirstOrDefault(emp => emp.Id == id);

            return nonEmp == null;
        }
    }
}
