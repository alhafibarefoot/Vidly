using EntityFramework.Seeder;
namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
     using System.IO;
    using System.Reflection;
    using System.Text;
    using Vidly.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.Models.ApplicationDbContext context)
       
        {
            context.Countries.SeedFromResource("Vidly.Models.SeedData.countries.csv", c => c.Code);
            context.SaveChanges();
            context.ProvinceStates.SeedFromResource("Vidly.Models.SeedData.provincestates.csv", p => p.Code,
                new CsvColumnMapping<ProvinceState>("CountryCode", (state, countryCode) =>
                {
                    state.Country = context.Countries.Single(c => c.Code == countryCode);
                })
             );            
        }
    }
}
