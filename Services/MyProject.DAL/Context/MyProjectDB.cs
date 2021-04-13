using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities.Identity;
using MyProject.Domain.Models;

namespace MyProject.DAL.Context
{
    public class MyProjectDB : IdentityDbContext<User, Role, string>
    {
        public DbSet<Employee> Employees { get; set; }

        public MyProjectDB(DbContextOptions<MyProjectDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}
