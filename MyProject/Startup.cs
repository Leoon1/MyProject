using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyProject.DAL.Context;
using MyProject.Interfaces.Services;
using MyProject.ServiceHosting.Data;
using MyProject.Servises.Data;
using MyProject.Servises.Employees;

namespace MyProject.ServiceHosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MyProjectDB>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddTransient<MyProjectDbInitializer>();
            services.AddScoped<IEmployeesData, MySqlEmployeesData>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1" });
            });
            //services.AddDbContext<MyProjectDB>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyProjectDbInitializer dbInitializer)
        {
            dbInitializer.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
