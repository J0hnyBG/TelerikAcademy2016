using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_Countries.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Language { get; set; }

        public long Population { get; set; }

        public virtual Continent Continent { get; set; }

        public int ContinentId { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
