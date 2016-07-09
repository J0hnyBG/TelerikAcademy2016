namespace TradeAndTravel
{
    using System.Collections.Generic;
    public class Wood : Item
    {
        private const int WoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.WoodValue, ItemType.Wood, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron };
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value -= 1;
            }
            else
            {
                base.UpdateWithInteraction(interaction);
            }
        }
    }
}
