namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string _name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(ErrorMessages.StringNullOrEmptyErrorMessage, "Pilot name"));
                this._name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.CheckIfObjectIsNull(machine, string.Format(ErrorMessages.ObjectNullErrorMessage, "Machine"));
            this.machines.Add(machine);
        }

        public string Report()
        {
            var orderedMachines = machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name).ToList();
            var count = orderedMachines.Count.ToString();
            var areMultipleMachines = "machines";

            if (orderedMachines.Count == 0)
            {
                return string.Format("{0} - no machines", this.Name);
            }
            else if (orderedMachines.Count == 1)
            {
                areMultipleMachines = "machine";
            }
            
            var sb = new StringBuilder();
            sb.Append(string.Format("{0} - {1} {2}", this.Name, count, areMultipleMachines));

            foreach (var mach in orderedMachines)
            {
                sb.Append(mach.ToString());
            }
            return sb.ToString();
        }
    }
}
