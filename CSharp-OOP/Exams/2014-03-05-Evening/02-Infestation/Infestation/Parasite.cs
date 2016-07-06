namespace Infestation
{
    public class Parasite : InfestingUnit
    {
        public const int ParasitePower = 1;
        public const int ParasiteAggresion = 1;
        public const int ParasiteHealth = 1;

        public Parasite(string id) 
            : base(id, UnitClassification.Biological, Parasite.ParasiteHealth, Parasite.ParasitePower, Parasite.ParasiteAggresion)
        {
        }
    }
}
