using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using todoapp.business.Abstract;
using todoapp.business.Concrete;
using todoapp.data.Abstract;
using todoapp.data.Concrete;
using todoapp.webui.Identity;

namespace todoapp.webui
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {   
            // Identity configures
            services.AddDbContext<IdentityContext>(options => options.UseSqlite("Data Source = taskDb"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {

                // Password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
                options.Lockout.AllowedForNewUsers = true; // make lockout active

                // User
                options.User.RequireUniqueEmail = false;

                // Sign In
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            // Cookie Settings
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/account/login"; // If there is no cookie
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".todoapp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
            // Using Views
            services.AddControllersWithViews();

            // Dependency Injections
            services.AddScoped<ITaskRepository, EfCoreTaskRepository>();
            services.AddScoped<ITaskService, TaskManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                // Seeding
                //SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication(); // Don't forget that.
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
