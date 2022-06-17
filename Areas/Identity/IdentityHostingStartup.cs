using System;
using AdayOgrenci.Areas.Identity.Data;
using AdayOgrenci.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AdayOgrenci.Areas.Identity.IdentityHostingStartup))]
namespace AdayOgrenci.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AdayOgrenciAuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdayOgrenciAuthDbContextConnection")));

                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddEntityFrameworkStores<AdayOgrenciAuthDbContext>();
                services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<AdayOgrenciAuthDbContext>();
                services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                    opt =>
                    {
                        opt.LoginPath = "/Identity/Account/Login";
                        opt.AccessDeniedPath = "/Admission/Index";
                    });
            });
        }
    }
}