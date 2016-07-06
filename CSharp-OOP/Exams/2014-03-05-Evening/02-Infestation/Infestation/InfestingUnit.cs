namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class InfestingUnit : Unit
    {
        protected InfestingUnit(string id, UnitClassification type, int health, int power, int aggression) 
            : base(id, type, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where(this.CanAttackUnit);

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if ( optimalAttackableUnit.Id != null )
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }
            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the least health and attacks it
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach ( var unit in attackableUnits )
            {
                if ( unit.Health < optimalAttackableUnit.Health )
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if ( this.Id != unit.Id
                && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) )
            {
                return true;
            }
            return false;
        }
    }
}
