using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager:InteractionManager
    {
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
                default: item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break; 
                default: location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default: person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords,actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords,actor);
                    break;

                default: base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            List<Item> itemsByLocation = strayItemsByLocation[actor.Location];
            List<Item> personInventory = actor.ListInventory();

            if (actor.Location.GetType().Name == "Mine")
            {
                foreach (var inventory in personInventory)
                {
                    if (inventory.GetType().Name == "Armor")
                    {
                        AddToPerson(actor, new Iron(commandWords[2], actor.Location));
                        //actor.AddToInventory(new Iron(commandWords[2], actor.Location));
                        break;
                    }
                }
            }
            else if (actor.Location.GetType().Name == "Forest")
            {
                foreach (var inventory in personInventory)
                {
                    if (inventory.GetType().Name == "Weapon")
                    {
                        AddToPerson(actor, new Wood(commandWords[2], actor.Location));
                        //actor.AddToInventory(new Wood(commandWords[2], actor.Location));
                        break;
                    }
                }
            }           
        }

        protected void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            bool hasIron = false;
            bool hasWood = false;

            List<Item> personInventory = actor.ListInventory();

            if (commandWords[2] == "weapon")
            {
                foreach (var inventory in personInventory)
                {
                    if (inventory.GetType().Name == "Iron") hasIron = true;
                    if (inventory.GetType().Name == "Wood") hasWood = true;
                }
                if (hasIron && hasWood)  AddToPerson(actor, new Weapon(commandWords[3], actor.Location));
                
            }
            else if(commandWords[2] == "armor")
            {
                foreach (var inventory in personInventory)
                {
                    if (inventory.GetType().Name == "Iron")
                    {
                        AddToPerson(actor, new Armor(commandWords[3]));
                        //actor.AddToInventory(new Armor(commandWords[3]));
                        break;
                    }
                }
            }
        }

    }
}
