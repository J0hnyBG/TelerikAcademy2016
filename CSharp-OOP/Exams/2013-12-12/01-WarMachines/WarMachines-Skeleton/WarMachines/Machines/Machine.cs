namespace WarMachines.Machines
{
    using System.Collections.Generic;

    using WarMachines.Interfaces;

    public class Machine : IMachine
    {
        private string _name;
        private IPilot _pilot;
        private IList<string> _targets;

        protected Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
           this.Name = name;
           this.HealthPoints = healthPoints;
           this.AttackPoints = attackPoints;
           this.DefensePoints = defensePoints;
           this._targets = new List<string>();
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(ErrorMessages.StringNullOrEmptyErrorMessage, "Machine name"));
                this._name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this._pilot; }
            set
            {
                Validator.CheckIfObjectIsNull(value, string.Format(ErrorMessages.ObjectNullErrorMessage, "Pilot"));
                this._pilot = value;
            }
        }

        public double HealthPoints { get; set; }
        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get { return this._targets; }
        }

        public void Attack(string target)
        {
            Validator.CheckIfStringIsNullOrEmpty(target, string.Format(ErrorMessages.StringNullOrEmptyErrorMessage, "Target"));
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var targetsString = string.Join(", ", this.Targets);
            if (this.Targets.Count == 0)
            {
                targetsString = "None";
            }
            return string.Format("\n- {0}\n *Type: {1}\n *Health: {2}\n *Attack: {3}\n *Defense: {4}\n *Targets: {5}\n",
                this._name, this.GetType().Name, this.HealthPoints, this.AttackPoints, this.DefensePoints, targetsString);
        }
    }
}
