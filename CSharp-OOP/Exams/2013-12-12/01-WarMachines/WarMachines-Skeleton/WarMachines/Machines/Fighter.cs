namespace WarMachines.Machines
{
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const int FighterInitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealhMode) 
            : base(name, Fighter.FighterInitialHealthPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealhMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }
        public override string ToString()
        {
            return base.ToString() + " *Stealth: " + (this.StealthMode ? "ON" : "OFF");
        }
 
    }
}
