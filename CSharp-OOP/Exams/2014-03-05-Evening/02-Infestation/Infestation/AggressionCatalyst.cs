namespace Infestation
{
    public class AggressionCatalyst : Supplement
    {
        private const int AggresionCatalystPower = 0;
        private const int AggresionCatalystHealth = 0;
        private const int AggresionCatalystAggresion = 3;

        public AggressionCatalyst() 
            : base(AggressionCatalyst.AggresionCatalystPower, AggressionCatalyst.AggresionCatalystHealth, AggressionCatalyst.AggresionCatalystAggresion)
        {
        }

    }
}