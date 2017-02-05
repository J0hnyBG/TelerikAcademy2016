using _02_Todo.Data.Models;

namespace _02_Todo.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.TodoAppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.TodoAppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new[] { "Immediate", "Critical", "Normal", "Optional", "Drop" };
                foreach (var categoryName in categories)
                {
                    var c = new Category()
                            {
                                Name = categoryName
                            };

                    context.Categories.Add(c);
                }

                context.SaveChanges();
            }
        }
    }
}
