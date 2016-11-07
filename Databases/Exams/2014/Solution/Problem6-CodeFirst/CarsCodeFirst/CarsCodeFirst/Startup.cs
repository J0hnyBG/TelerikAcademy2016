using CarsCodeFirst.Data;

namespace CarsCodeFirst
{
    public class Startup
    {
        private static void Main(string[] args)
        {
            var db = new CarsDbModel();

            db.Database.CreateIfNotExists();
        }
    }
}
