namespace SuperheroesUniverse.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Models;

    public class SuperheroesUniverseDbContext : DbContext
    {
        public SuperheroesUniverseDbContext()
            : base("name=SuperheroesUniverseDbContext")
        {
            this.Database.CreateIfNotExists();
        }

        public virtual IDbSet<Power> Powers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Superhero> Superheroes { get; set; }

        public virtual IDbSet<Fraction> Fractions { get; set; }

        public virtual IDbSet<HeroRelationship> HeroRelationships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HeroRelationship>().HasKey(r => r.Id);
            //modelBuilder.Entity<HeroRelationship>()
            //            .HasRequired(r => r.Superhero)
            //            .WithMany(x => x.Relationships)
            //            .HasForeignKey(x => new { x.SuperheroId, x.SecondHeroId });
            //modelBuilder.Entity<HeroRelationship>()
            //    .HasKey(t => new { t.SuperheroId, t.SecondHeroId});

            //modelBuilder.Entity<HeroRelationship>().HasRequired(t => t.Superhero)
            //            .WithMany(s => s.Relationships)
            //            .Map(m => m.MapKey("OneId").MapKey(new string[] { "SuperheroId", "SecondHeroId" }));
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.
        }
    }
}
