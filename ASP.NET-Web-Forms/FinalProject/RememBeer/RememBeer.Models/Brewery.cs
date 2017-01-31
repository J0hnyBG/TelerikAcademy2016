using System.Collections.Generic;

namespace RememBeer.Models
{
    public class Brewery
    {
        private ICollection<Beer> beers;

        public Brewery()
        {
            this.Beers = new HashSet<Beer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public ICollection<Beer> Beers
        {
            get
            {
                return this.beers;
            }
            set
            {
                this.beers = value;
            }
        }
    }
}
