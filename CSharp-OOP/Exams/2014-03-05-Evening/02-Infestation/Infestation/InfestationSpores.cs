namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int InfestationSporesPower = -1;
        private const int InfestationSporesHealth = 0;
        private const int InfestationSporesAggression = 20;

        public InfestationSpores() 
            : base(InfestationSpores.InfestationSporesPower, InfestationSpores.InfestationSporesHealth, InfestationSpores.InfestationSporesAggression)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
            else
            {
                base.ReactTo(otherSupplement);
            }
        }
    }
}
