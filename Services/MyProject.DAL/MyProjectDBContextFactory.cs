using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyProject.DAL.Context;

namespace MyProject.DAL
{

    public class MyProjectDBContextFactory : IDesignTimeDbContextFactory<MyProjectDB>
    {
        public MyProjectDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyProjectDB>();
            const string con_str = @"server=localhost; port=3306; database=test; user=root; password=1q2w3e4r5t; Persist Security Info=False; Connect Timeout=300";
            optionsBuilder.UseMySql(con_str, new MySqlServerVersion(new Version(8, 0, 23)));

            return new MyProjectDB(optionsBuilder.Options);
        }
    }
}
