using System;

using RememBeer.WebClient.Models;

namespace RememBeer.Models
{
    public class BeerReview
    {
        public Beer Beer { get; set; }

        public ApplicationUser User { get; set; }

        public int Overall { get; set; }

        public int Look { get; set; }

        public int Smell { get; set; }

        public int Taste { get; set; }

        public int MouthFeel { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsPublic { get; set; }

        public DateTime DateOfConsumption { get; set; }

        public string Place { get; set; }
    }
}
