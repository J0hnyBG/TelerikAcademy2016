namespace SuperheroesUniverse.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class HeroRelationship
    {
        public int Id { get; set; }

        public int SuperheroId { get; set; }
        public virtual Superhero Superhero { get; set; }

        public int SecondHeroId { get; set; }
        public virtual Superhero SecondHero { get; set; }

        public RelationshipType Relationship { get; set; }
    }
}
