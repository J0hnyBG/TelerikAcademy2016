using WarMachines.Engine;

namespace WarMachines.Machines
{
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const int TankInitialHealthPoints = 100;

        private bool _defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, Tank.TankInitialHealthPoints, attackPoints, defensePoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode
        {
            get { return this._defenseMode; }
            private set
            {
                if (value)
                {
                    this.AttackPoints -= 40;
                    this.DefensePoints += 30;
                }
                else
                {
                    this.AttackPoints += 40;
                    this.DefensePoints -= 30;
                }
                this._defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }
        public override string ToString()
        {
            return base.ToString() + " *Defense: " + ( this.DefenseMode ? "ON" : "OFF" );
        }
    }
}
