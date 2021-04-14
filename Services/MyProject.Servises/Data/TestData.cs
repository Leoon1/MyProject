using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Servises.Data
{
    /// <summary>
    /// Тестовые данные по клиентам
    /// </summary>
    public class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>()
        {
            new Employee { FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович", Age = 26, Email = "ii@list.ru"},
            new Employee { FirstName = "Пётр", LastName = "Петров", Patronymic = "Петрович", Age = 35, Email = "pp@zz.br"},
            new Employee { FirstName = "Сидор", LastName = "Сидоров", Patronymic = "Сидорович", Age = 15, Email = "ikn@.ap.ua"},
            new Employee { FirstName = "Леонид", LastName = "Петров", Patronymic = "Михайлович", Age = 25, Email = "1@bk.ru" },
            new Employee { FirstName = "Аркадий", LastName = "Укупник", Patronymic = "Артемович", Age = 70, Email = "2@ap.ua" },
            new Employee { FirstName = "Конан", LastName = "Доил", Patronymic = "Иванович", Age = 90, Email = "99@gmail.com" }
        };
    }
}
