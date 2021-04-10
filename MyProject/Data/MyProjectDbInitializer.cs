using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.DAL.Context;
using MyProject.Domain.Models;

namespace MyProject.ServiceHosting.Data
{
    public class MyProjectDbInitializer
    {
        private readonly MyProjectDB _db;
        private readonly ILogger<MyProjectDbInitializer> _logger;

        public MyProjectDbInitializer(MyProjectDB db, ILogger<MyProjectDbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void Initialize()
        {
            var db = _db.Database;

            if (db.GetPendingMigrations().Any())
                db.Migrate();

            InitializeEmployees();
        }

        private void InitializeEmployees()
        {
            if(_db.Employees.Any())
                return;

            using (_db.Database.BeginTransaction())
            {
                _db.Employees.AddRange(
                    new Employee { FirstName = "Леонид", LastName = "Петров", Patronymic = "Михайлович", Age = 25, Email = "1@bk.ru" },
                    new Employee { FirstName = "Аркадий", LastName = "Укупник", Patronymic = "Артемович", Age = 70, Email = "2@ap.ua" },
                    new Employee { FirstName = "Конан", LastName = "Доил", Patronymic = "Иванович", Age = 90, Email = "99@gmail.com" }
                    );

                _db.SaveChanges();
                _db.Database.CommitTransaction();
            }
        }
    }
}
