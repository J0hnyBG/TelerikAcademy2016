namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if ( rounds <= 0 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be between 0 and 9, inclusive");
            }
            this.rounds = rounds;
        }

        //TODO: maybe
        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if ( attackerWithSpecialty == null )
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if ( defender == null )
            {
                throw new ArgumentNullException("defender");
            }

            if ( this.rounds <= 0 )
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }
            this.rounds--;
            return currentDamage * 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", this.GetType().Name, this.rounds);
        }
    }
}
