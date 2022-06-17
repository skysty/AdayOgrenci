﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdayOgrenci.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdayOgrenci.Data
{
    public class AdayOgrenciAuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AdayOgrenciAuthDbContext()
        {
            Database.EnsureCreated();
        }
        public AdayOgrenciAuthDbContext(DbContextOptions<AdayOgrenciAuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CCUKK5O; User Id=sa; Password=123456;Initial Catalog=AdayOgrenciAuthDb;Integrated Security=True");
        }
    }
}
