using System.ComponentModel.DataAnnotations;

namespace _01_Countries.Models
{
    public class Town
    {
        public int Id { get; set; }

        public int Population { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public int CountryId { get; set; }
    }
}