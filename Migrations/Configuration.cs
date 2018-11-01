namespace IndygoWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IndygoWeb.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<IndygoWeb.Models.IndygoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IndygoWeb.Models.IndygoContext context)
        {
            context.Companies.AddOrUpdate(x => x.CompanyId,
                new Company()
                {
                    CompanyId = 1,
                    CompanyName = "Indygo",
                    CompanyCity = "Philadelphia",
                    CompanyCountry = "United States",
                    CompanyPhone = "555-555-5555",
                    CompanyStreetAddress = "Test street",
                    CompanyWebsite = "google.com"
                });

        }
    }
}
