using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using todoapp.data.Concrete;
using todoapp.webui.Identity;

namespace todoapp.webui.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var applicationContext = scope.ServiceProvider.GetRequiredService<IdentityContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // logging
                        throw;
                    }
                }

                using (var applicationContext = scope.ServiceProvider.GetRequiredService<TaskContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // logging
                        throw;
                    } 
            }
            }

            return host;
                
        }
    }
}