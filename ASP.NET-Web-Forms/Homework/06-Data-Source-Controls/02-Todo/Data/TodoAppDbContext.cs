using _02_Todo.Data.Models;

namespace _02_Todo.Data
{
    using System.Data.Entity;

    public class TodoAppDbContext : DbContext
    {
        // Your context has been configured to use a 'TodoAppDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_02_Todo.Data.TodoAppDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TodoAppDbContext' 
        // connection string in the application configuration file.
        public TodoAppDbContext()
            : base("name=TodoAppDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<Todo> Todos { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
    }
}