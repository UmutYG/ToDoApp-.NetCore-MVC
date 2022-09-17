using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using todoapp.business.Abstract;
using todoapp.business.Concrete;
using todoapp.data.Abstract;
using todoapp.data.Concrete;

namespace todoapp.webui
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ITaskRepository, EfCoreTaskRepository>();
            services.AddScoped<ITaskService, TaskManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "edit",
                    defaults: new {controller ="Home", action="Edit"}
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{status}",
                    defaults: new {controller ="Home", action="Index"}
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}"
                );
            });
        }
    }
}
