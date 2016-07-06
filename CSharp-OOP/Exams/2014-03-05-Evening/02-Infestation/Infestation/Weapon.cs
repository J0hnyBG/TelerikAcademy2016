namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int WeaponPower = 0;
        private const int WeaponHealth = 0;
        private const int WeaponAggresion = 0;
        private const int WeaponActivatedPower = 10;
        private const int WeaponActivatedAggression = 3;
        public Weapon() 
            : base(Weapon.WeaponPower, Weapon.WeaponHealth, Weapon.WeaponAggresion)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect += Weapon.WeaponActivatedPower;
                this.AggressionEffect += Weapon.WeaponActivatedAggression;
            }
            else
            {
                base.ReactTo(otherSupplement);
            }
        }
    }
}