namespace TradeAndTravel
{
    using System.Linq;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant":
                    return new Merchant(personNameString, personLocation);
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            switch (locationTypeString)
            {
                case "mine":
                    return new Mine(locationName);
                case "forest":
                    return new Forest(locationName);
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherCommand(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftCommand(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftCommand(string[] commandWords, Person actor)
        {
            var actorInventory = actor.ListInventory();

            if(commandWords[2] == "weapon" && actorInventory.OfType<Wood>().Any() && actorInventory.OfType<Iron>().Any())
            { 
                this.AddToPerson(actor, new Weapon(commandWords[3]));
            }
            else if (commandWords[2] == "armor" && actorInventory.OfType<Iron>().Any())
            {
                this.AddToPerson(actor, new Armor(commandWords[3]));
            }
        }

        private void HandleGatherCommand(string[] commandWords, Person actor)
        {
            var actorInventory = actor.ListInventory();

            if (actor.Location is Forest && actorInventory.OfType<Weapon>().Any())
            {
                this.AddToPerson(actor, new Wood(commandWords[2]));
            }
            else if (actor.Location is Mine && actorInventory.OfType<Armor>().Any())
            {
                this.AddToPerson(actor, new Iron(commandWords[2]));
            }
        }
    }


}
