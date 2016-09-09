using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.MyTests.Logic.Battles.Mocks
{
    public class MockedBattleManager : BattleManager
    {
       
        public MockedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger) : base(creaturesFactory, logger)
        {
            this.FirstArmyofCreatures = new List<ICreaturesInBattle>();
            this.SecondArmyOfCreatures = new List<ICreaturesInBattle>();
        }

        public ICollection<ICreaturesInBattle> FirstArmyofCreatures;
        public ICollection<ICreaturesInBattle> SecondArmyOfCreatures;

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber == 1)
            {
                return
                    this.FirstArmyofCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            else
            {
                return this.SecondArmyOfCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if ( creatureIdentifier.ArmyNumber == 1 )
            {
                this.FirstArmyofCreatures.Add(creaturesInBattle);
            }
            else if ( creatureIdentifier.ArmyNumber == 2 )
            {
                this.SecondArmyOfCreatures.Add(creaturesInBattle);
            }
        }
    }
}
