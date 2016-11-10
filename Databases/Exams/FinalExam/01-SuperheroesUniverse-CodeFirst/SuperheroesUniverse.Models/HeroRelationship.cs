namespace SuperheroesUniverse.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class HeroRelationship
    {
        [Key, Column(Order = 0)]
        public int SuperheroId { get; set; }
        [Column("SuperheroId")]
        public virtual Superhero Superhero { get; set; }

        [Key, Column(Order = 1)]
        public int SecondHeroId { get; set; }
        [Column("SecondHeroId")]
        public virtual Superhero SecondHero { get; set; }

        public RelationshipType Relationship { get; set; }
    }
}
