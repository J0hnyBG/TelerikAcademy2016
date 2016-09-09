using System.Collections.Generic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using Moq;

namespace ArmyOfCreatures.MyTests.Logic.Battles.Mocks
{
    public class MockedCreature : Creature
    {

        public MockedCreature(int attack, int defense, int healthPoints, decimal damage)
            : base(attack, defense, healthPoints, damage)
        {
            this.Init();
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
        public new ICollection<Mock<Specialty>> Specialties { get; set; }


        private void Init()
        {
            var mockedSpecialty = new Mock<Specialty>();
            mockedSpecialty.Setup(x => x.ApplyOnSkip(It.IsAny<ICreaturesInBattle>()));

            this.Specialties = new List<Mock<Specialty>>
            {
                mockedSpecialty,
                mockedSpecialty,
                mockedSpecialty,
            };
        }

    }
}