namespace Infestation
{
    public class Supplement : ISupplement
    {
        protected Supplement(int powerEffect, int healthEffect, int aggresionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggresionEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
            //no base reaction
        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }
    }
}
