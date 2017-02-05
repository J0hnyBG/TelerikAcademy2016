using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_Countries.Models
{
    public class Continent
    {
        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}