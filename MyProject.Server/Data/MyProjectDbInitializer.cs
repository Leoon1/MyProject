using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.Server.Models;

namespace MyProject.Server.Data
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    public class MyProjectDbInitializer
    {
        private readonly ApplicationDbContext db;
        //private readonly UserManager<User> userManager;
        //private readonly RoleManager<Role> roleManager;
        private readonly ILogger<MyProjectDbInitializer> logger;

        public MyProjectDbInitializer(
            ApplicationDbContext db,
            UserManager<User> userManager,
            //RoleManager<Role> roleManager,
            ILogger<MyProjectDbInitializer> logger)
        {
            this.db = db;
            //this.userManager = userManager;
            //this.roleManager = roleManager;
            this.logger = logger;
        }

        /// <summary>
        /// Инициализация БД миграцией, если есть миграции, не выполненные у клиента
        /// </summary>
        public void Initialize()
        {
            //this.logger.LogInformation("Инициализация БД...");

            var db = this.db.Database;

            if (db.GetPendingMigrations().Any())
            {
                this.logger.LogInformation("Есть не примененные миграции...");
                db.Migrate();
                this.logger.LogInformation("Миграции БД выполнены успешно");
            }
            else
                this.logger.LogInformation("Структура БД в актуальном состоянии.");

        }

    }
}
