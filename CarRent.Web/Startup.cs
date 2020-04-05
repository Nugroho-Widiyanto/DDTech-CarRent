using CarRent.Core.Core;
using CarRent.Core.Persistence;
using CarRent.Web.Services;
using CarRent.Web.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace CarRent.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            var appDataPath = Path.Combine(env.ContentRootPath, "App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);
            //string relative = @"..\..\App_Data\CarRent.mdf";
            //string absolute = Path.GetDirectoryName(relative);
            //AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
            ////Database.SetInitializer(new
            ////    MigrateDatabaseToLatestVersion<Projekt5Context, Configuration>()
            //// );

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CarRentContext>(options =>
                options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("CarRent.Core")));

            services.AddControllersWithViews();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRentCalculatorService, RentCalculatorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
