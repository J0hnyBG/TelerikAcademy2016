using System.ComponentModel.DataAnnotations;

namespace CarsCodeFirst.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }
        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        public int DealerId { get; set; }
        [Required]
        public virtual Dealer Dealer { get; set; }

        [Required]
        [StringLength(20)]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        public short Year { get; set; }

        public decimal Price { get; set; }
    }
}
