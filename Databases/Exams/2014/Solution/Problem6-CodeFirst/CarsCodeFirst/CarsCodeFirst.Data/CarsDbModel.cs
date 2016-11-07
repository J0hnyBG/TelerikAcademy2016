using CarsCodeFirst.Models;

namespace CarsCodeFirst.Data
{
    using System.Data.Entity;

    public class CarsDbModel : DbContext
    {
        public CarsDbModel()
            : base("name=CarsDbModel")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Dealer> Dealers { get; set; }
    }
}