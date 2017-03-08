using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

using Movies.Models;

namespace Movies.Data
{
    using System;
    using System.Data.Entity;

    public interface IMoviesDbContext: IDisposable
    {
        DbSet<Movie> Movies { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbEntityEntry Entry(object entity);
    }

    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        // Your context has been configured to use a 'MoviesDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Movies.Data.MoviesDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MoviesDbContext' 
        // connection string in the application configuration file.
        public MoviesDbContext()
            : base("name=MoviesDbContext")
        {
            this.Database.CreateIfNotExists();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Movie> Movies { get; set; }
    }
}