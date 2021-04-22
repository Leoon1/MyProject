using System.Collections.Generic;
using MyProject.Server.Models;

namespace MyProject.Server.Data
{
    /// <summary>
    /// Тестовые данные по клиентам
    /// </summary>
    public class TestData
    {
        public static List<User> Users { get; } = new List<User>()
        {
            new User { FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович", Age = 26, Email = "ii@list.ru"},
            new User { FirstName = "Пётр", LastName = "Петров", Patronymic = "Петрович", Age = 35, Email = "pp@zz.br"},
            new User { FirstName = "Сидор", LastName = "Сидоров", Patronymic = "Сидорович", Age = 15, Email = "ikn@.ap.ua"},
            new User { FirstName = "Леонид", LastName = "Петров", Patronymic = "Михайлович", Age = 25, Email = "1@bk.ru" },
            new User { FirstName = "Аркадий", LastName = "Укупник", Patronymic = "Артемович", Age = 70, Email = "2@ap.ua" },
            new User { FirstName = "Конан", LastName = "Доил", Patronymic = "Иванович", Age = 90, Email = "99@gmail.com" }
        };
    }
}
