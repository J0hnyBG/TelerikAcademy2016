namespace TradeAndTravel
{
    using System.Collections.Generic;
    public class Iron : Item
    {
        private const int IronValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.IronValue, ItemType.Iron, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron };
        }
    }
}
