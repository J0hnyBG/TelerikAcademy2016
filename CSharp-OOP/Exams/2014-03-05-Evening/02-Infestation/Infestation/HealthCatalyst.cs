namespace Infestation
{
    public class HealthCatalyst : Supplement
    {
        private const int HealthCatalystPower = 0;
        private const int HealthCatalystHealth = 3;
        private const int HealthCatalystAggression = 0;

        public HealthCatalyst() 
            : base(HealthCatalyst.HealthCatalystPower, HealthCatalyst.HealthCatalystHealth, HealthCatalyst.HealthCatalystAggression)
        {
        }
    }
}