namespace Infestation
{
    using System.Collections.Generic;

    public sealed class Marine : Human
    {
        public Marine(string id) : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MinValue, int.MinValue,
                0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Power > optimalAttackableUnit.Power)
                {
                    optimalAttackableUnit = unit;
                }
                else if (unit.Power == optimalAttackableUnit.Power && unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}