namespace Infestation
{
    public class Tank : Unit
    {
        public const int TankPower = 25;
        public const int TankAggresion = 25;
        public const int TankHealth = 20;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, Tank.TankHealth, Tank.TankPower, Tank.TankAggresion)
        {
        }
    }
}
