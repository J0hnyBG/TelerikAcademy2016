using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

using Ploeh.AutoFixture;

using _01_Countries.Data;
using _01_Countries.Models;

namespace _01_Countries.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CountriesAndTownsDbContext>
    {
        private const int NumberOfCountries = 100;
        private const int NumberOfTowns = 1000;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "_01_Countries.Data.CountriesAndTownsDbContext";
        }

        protected override void Seed(CountriesAndTownsDbContext context)
        {
            var fixture = new Fixture();
            var random = new Random();
            var continents = new List<Continent>();
            var continentNames = new[]
                                 {
                                     "Africa", "Asia", "Antarctica", "Australia", "Europe", "North America",
                                     "South America"
                                 };
            foreach (var name in continentNames)
            {
                var continent = new Continent()
                                {
                                    Name = name
                                };
                continents.Add(continent);
                context.Continents.Add(continent);
            }

            SaveChanges(context);

            var countries = new List<Country>();
            for (int i = 0; i < NumberOfCountries; i++)
            {
                var continent = continents[random.Next(0, continents.Count)];
                var country = new Country()
                              {
                                  Name = fixture.Create<string>("Country: "),
                                  Population = random.Next(10000, 200000000),
                                  Continent = continent,
                                  ContinentId = continent.Id,
                                  Language = fixture.Create<string>("Lang: ")
                              };
                countries.Add(country);
                context.Countries.Add(country);
            }

            SaveChanges(context);

            for (int i = 0; i < NumberOfTowns; i++)
            {
                var country = countries[random.Next(0, countries.Count)];
                var town = new Town
                           {
                               Population = random.Next(100, 10000000),
                               Country = country,
                               CountryId = country.Id,
                               Name = fixture.Create<string>("Town: ")
                           };

                context.Towns.Add(town);
            }

            SaveChanges(context);
        }

        private static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }
        }
    }
}
