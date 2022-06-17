using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci.Entity
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CCUKK5O;User Id=sa; Password=123456;Initial Catalog=AdayOgrenci;Integrated Security=True");
        }
    }
}
