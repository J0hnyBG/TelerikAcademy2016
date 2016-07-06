namespace Infestation
{
    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unit = GetUnit(commandWords[2]);
            var supplement = GetSupplementByName(commandWords[1]);
            if (supplement != null)
            {
                unit.AddSupplement(supplement);
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        private static ISupplement GetSupplementByName(string name)
        {
            switch (name)
            {
                case "AggressionCatalyst":
                    return new AggressionCatalyst();
                case "PowerCatalyst":
                    return new PowerCatalyst();
                case "HealthCatalyst":
                    return new HealthCatalyst();
                case "InfestationSpores":
                    return new InfestationSpores();
                case "Weapon":
                    return new Weapon();
                default:
                    return null;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch ( interaction.InteractionType )
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}