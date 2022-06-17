using AdayOgrenci.Areas.Identity.Data;
using AdayOgrenci.Data;
using AdayOgrenci.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<AdayOgrenciAuthDbContext>();
                var userMgr = services.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleMgr = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                dbContext.Database.Migrate();

                var adminRole = new IdentityRole("Admin");

                if (!dbContext.Roles.Any())
                {
                    roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                }

                if (!dbContext.Users.Any(u => u.UserName == "admin"))
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                    };
                    var result = userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                    userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
