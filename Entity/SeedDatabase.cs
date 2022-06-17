using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci.Entity
{
    public class SeedDatabase
    {
        public static void Seed()
        {
            var context = new DataContext();
            context.Database.EnsureCreated();
            if (context.Database.GetPendingMigrations().Count() < 1)
            {
                if (context.Countries.Count() == 0)
                {
                    context.Countries.AddRange(Countries);
                    context.SaveChanges();
                }
            }
        }

        private static Country[] Countries =
        {
            new Country(){CountryName="Afghanistan",TwoCharCode="AF",ThreeCharCode="AFG"},
            new Country(){CountryName="Aland Islands",TwoCharCode="AX",ThreeCharCode="ALA" }
        };
    }
}
