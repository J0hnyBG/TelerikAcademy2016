using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Released")]
        public DateTime? Year { get; set; }

        [DisplayName("Lead Male Role")]
        public string LeadMale { get; set; }

        [DisplayName("Lead Female Role")]
        public string LeadFemale { get; set; }

        [Required]
        public string Studio { get; set; }

        [DisplayName("Studio Address")]
        public string StudioAddress { get; set; }
    }
}