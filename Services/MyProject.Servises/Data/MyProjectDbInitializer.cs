using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.DAL.Context;
using MyProject.Domain.Models;

namespace MyProject.Servises.Data
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
                _db.Employees.AddRange(TestData.Employees);

                _db.SaveChanges();
                _db.Database.CommitTransaction();
            }
        }
    }
}
