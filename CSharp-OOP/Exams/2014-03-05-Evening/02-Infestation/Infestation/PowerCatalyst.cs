namespace Infestation
{
    public class PowerCatalyst : Supplement
    {
        private const int PowerCatalystPower = 3;
        private const int PowerCatalystHealth = 0;
        private const int PowerCatalystAggression = 0;

        public PowerCatalyst() 
            : base(PowerCatalystPower, PowerCatalystHealth, PowerCatalystAggression)
        {
        }
    }
}