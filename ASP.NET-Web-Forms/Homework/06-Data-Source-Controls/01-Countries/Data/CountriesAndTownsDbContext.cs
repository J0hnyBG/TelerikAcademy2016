using _01_Countries.Models;

namespace _01_Countries.Data
{
    using System.Data.Entity;

    public class CountriesAndTownsDbContext : DbContext
    {
        // Your context has been configured to use a 'CountriesAndTownsDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_01_Countries.Data.CountriesAndTownsDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CountriesAndTownsDbContext' 
        // connection string in the application configuration file.
        public CountriesAndTownsDbContext()
            : base("name=CountriesAndTownsDbContext")
        {
            this.Database.CreateIfNotExists();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Continent> Continents { get; set; }
    }
}
