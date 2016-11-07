using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsCodeFirst.Models
{
    public class Dealer
    {
        private ICollection<City> cities;

        public Dealer()
        {
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }
    }
}
