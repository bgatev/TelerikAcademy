using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TradeAndTravel
{
    public class Armor : Item
    {
        const int GeneralArmorValue = 5;

        public Armor(string name, Location location = null)
            : base(name, Armor.GeneralArmorValue, ItemType.Armor, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron };
        }
    }
}

namespace TradeAndTravel
{
    public class Engine
    {

        protected InteractionManager interactionManager;

        public Engine(InteractionManager interactionManager)
        {
            this.interactionManager = interactionManager;
        }

        public void ParseAndDispatch(string command)
        {
            this.interactionManager.HandleInteraction(command.Split(' '));
        }

        public void Start()
        {
            bool endCommandReached = false;
            while (!endCommandReached)
            {
                string command = Console.ReadLine();
                if (command != "end")
                {
                    this.ParseAndDispatch(command);
                }
                else
                {
                    endCommandReached = true;
                }
            }
        }
    }
}

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

            //foreach (var item in itemsByLocation)
            {
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

namespace TradeAndTravel
{
    public class Forest:Location
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }
    }
}

namespace TradeAndTravel
{
    public interface IGatheringLocation
    {
        ItemType GatheredType
        {
            get;
        }

        ItemType RequiredItem
        {
            get;
        }


        Item ProduceItem(string name);
    }
}

namespace TradeAndTravel
{
    public class InteractionManager
    {
        const int InitialPersonMoney = 100;

        protected Dictionary<Person, int> moneyByPerson = new Dictionary<Person, int>();
        protected Dictionary<Item, Person> ownerByItem = new Dictionary<Item, Person>();
        protected Dictionary<Location, List<Item>> strayItemsByLocation = new Dictionary<Location, List<Item>>();

        protected HashSet<Location> locations = new HashSet<Location>();
        protected HashSet<Person> people = new HashSet<Person>();

        protected Dictionary<string, Person> personByName = new Dictionary<string, Person>();
        protected Dictionary<string, Location> locationByName = new Dictionary<string, Location>();
        protected Dictionary<Location, List<Person>> peopleByLocation = new Dictionary<Location, List<Person>>();

        public void HandleInteraction(string[] commandWords)
        {
            if (commandWords[0] == "create")
            {
                this.HandleCreationCommand(commandWords);
            }
            else
            {
                var actor = this.personByName[commandWords[0]];

                this.HandlePersonCommand(commandWords, actor);
            }
        }

        protected virtual void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "drop":
                    HandleDropInteraction(actor);
                    break;
                case "pickup":
                    HandlePickUpInteraction(actor);
                    break;
                case "sell":
                    this.HandleSellInteraction(commandWords, actor);
                    break;
                case "buy":
                    HandleBuyInteraction(commandWords, actor);
                    break;
                case "inventory":
                    HandleListInventoryInteraction(actor);
                    break;
                case "money":
                    Console.WriteLine(moneyByPerson[actor]);
                    break;
                case "travel":
                    HandleTravelInteraction(commandWords, actor);
                    break;
                default:
                    break;
            }
        }

        private void HandleTravelInteraction(string[] commandWords, Person actor)
        {
            var traveller = actor as ITraveller;
            if (traveller != null)
            {
                var targetLocation = this.locationByName[commandWords[2]];
                peopleByLocation[traveller.Location].Remove(actor);
                traveller.TravelTo(targetLocation);
                peopleByLocation[traveller.Location].Add(actor);

                foreach (var item in actor.ListInventory())
                {
                    item.UpdateWithInteraction("travel");
                }
            }
        }

        private void HandleListInventoryInteraction(Person actor)
        {
            var inventory = actor.ListInventory();
            foreach (var item in inventory)
            {
                if (ownerByItem[item] == actor)
                {
                    Console.WriteLine(item.Name);
                    item.UpdateWithInteraction("inventory");
                }
            }

            if (inventory.Count == 0)
            {
                Console.WriteLine("empty");
            }
        }

        private void HandlePickUpInteraction(Person actor)
        {
            foreach (var item in strayItemsByLocation[actor.Location])
            {
                this.AddToPerson(actor, item);
                item.UpdateWithInteraction("pickup");
            }
            strayItemsByLocation[actor.Location].Clear();
        }

        private void HandleDropInteraction(Person actor)
        {
            foreach (var item in actor.ListInventory())
            {
                if (ownerByItem[item] == actor)
                {
                    strayItemsByLocation[actor.Location].Add(item);
                    this.RemoveFromPerson(actor, item);

                    item.UpdateWithInteraction("drop");
                }
            }
        }

        private void HandleBuyInteraction(string[] commandWords, Person actor)
        {
            Item saleItem = null;
            string saleItemName = commandWords[2];
            var buyer = personByName[commandWords[3]] as Shopkeeper;

            if (buyer != null &&
                peopleByLocation[actor.Location].Contains(buyer))
            {
                foreach (var item in buyer.ListInventory())
                {
                    if (ownerByItem[item] == buyer && saleItemName == item.Name)
                    {
                        saleItem = item;
                    }
                }

                var price = buyer.CalculateSellingPrice(saleItem);
                moneyByPerson[buyer] += price;
                moneyByPerson[actor] -= price;
                this.RemoveFromPerson(buyer, saleItem);
                this.AddToPerson(actor, saleItem);

                saleItem.UpdateWithInteraction("buy");
            }
        }

        private void HandleSellInteraction(string[] commandWords, Person actor)
        {
            Item saleItem = null;
            string saleItemName = commandWords[2];
            foreach (var item in actor.ListInventory())
            {
                if (ownerByItem[item] == actor && saleItemName == item.Name)
                {
                    saleItem = item;
                }
            }

            var buyer = personByName[commandWords[3]] as Shopkeeper;
            if (buyer != null &&
                peopleByLocation[actor.Location].Contains(buyer))
            {
                var price = buyer.CalculateBuyingPrice(saleItem);
                moneyByPerson[buyer] -= price;
                moneyByPerson[actor] += price;
                this.RemoveFromPerson(actor, saleItem);
                this.AddToPerson(buyer, saleItem);

                saleItem.UpdateWithInteraction("sell");
            }
        }

        protected void AddToPerson(Person actor, Item item)
        {
            actor.AddToInventory(item);
            ownerByItem[item] = actor;
        }

        protected void RemoveFromPerson(Person actor, Item item)
        {
            actor.RemoveFromInventory(item);
            ownerByItem[item] = null;
        }

        protected void HandleCreationCommand(string[] commandWords)
        {
            if (commandWords[1] == "item")
            {
                string itemTypeString = commandWords[2];
                string itemNameString = commandWords[3];
                string itemLocationString = commandWords[4];
                this.HandleItemCreation(itemTypeString, itemNameString, itemLocationString);
            }
            else if (commandWords[1] == "location")
            {
                string locationTypeString = commandWords[2];
                string locationNameString = commandWords[3];
                this.HandleLocationCreation(locationTypeString, locationNameString);
            }
            else
            {
                string personTypeString = commandWords[1];
                string personNameString = commandWords[2];
                string personLocationString = commandWords[3];
                this.HandlePersonCreation(personTypeString, personNameString, personLocationString);
            }
        }

        protected virtual void HandleLocationCreation(string locationTypeString, string locationName)
        {
            Location location = CreateLocation(locationTypeString, locationName);

            locations.Add(location);
            strayItemsByLocation[location] = new List<Item>();
            peopleByLocation[location] = new List<Person>();
            locationByName[locationName] = location;
        }

        protected virtual void HandlePersonCreation(string personTypeString, string personNameString, string personLocationString)
        {
            var personLocation = locationByName[personLocationString];

            Person person = CreatePerson(personTypeString, personNameString, personLocation);

            personByName[personNameString] = person;
            peopleByLocation[personLocation].Add(person);
            moneyByPerson[person] = InteractionManager.InitialPersonMoney;
        }

        protected virtual void HandleItemCreation(string itemTypeString, string itemNameString, string itemLocationString)
        {
            var itemLocation = locationByName[itemLocationString];

            Item item = null;
            item = CreateItem(itemTypeString, itemNameString, itemLocation, item);

            ownerByItem[item] = null;
            strayItemsByLocation[itemLocation].Add(item);
        }

        protected virtual Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "armor":
                    item = new Armor(itemNameString, itemLocation);
                    break;
                default:
                    break;
            }
            return item;
        }

        protected virtual Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "shopkeeper":
                    person = new Shopkeeper(personNameString, personLocation);
                    break;
                case "traveller":
                    person = new Traveller(personNameString, personLocation);
                    break;
                default:
                    break;
            }
            return person;
        }

        protected virtual Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    location = new Town(locationName);
                    break;
                default:
                    break;
            }
            return location;
        }
    }
}

namespace TradeAndTravel
{
    public class Iron:Item
    {
        const int GeneralIronValue = 3;

        public Iron(string name, Location location)
            : base(name, Iron.GeneralIronValue, ItemType.Iron, location)
        {
        }
    }
}

namespace TradeAndTravel
{
    public interface IShopkeeper
    {
        int CalculateSellingPrice(Item item);

        int CalculateBuyingPrice(Item item);
    }
}

namespace TradeAndTravel
{
    public abstract class Item : WorldObject
    {
        public ItemType ItemType { get; private set; }

        public int Value { get; protected set; }

        protected Item(string name, int itemValue, string type, Location location = null)
            : base(name)
        {
            this.Value = itemValue;

            foreach (var itemType in (ItemType[])Enum.GetValues(typeof(ItemType)))
            {
                if (itemType.ToString() == type)
                {
                    this.ItemType = itemType;
                }
            }
        }

        protected Item(string name, int itemValue, ItemType type, Location location = null)
            : base(name)
        {
            this.Value = itemValue;
            this.ItemType = type;
        }

        public virtual void UpdateWithInteraction(string interaction)
        {
        }
    }
}

namespace TradeAndTravel
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Wood,
        Iron,
    }
}

namespace TradeAndTravel
{
    public interface ITraveller
    {
        void TravelTo(Location location);
        Location Location {get;}
    }
}

namespace TradeAndTravel
{
    public abstract class Location : WorldObject
    {
        public LocationType LocationType { get; private set; }

        public Location(string name, string type)
            : base(name)
        {
            foreach (var locType in (LocationType[])Enum.GetValues(typeof(LocationType)))
            {
                if (locType.ToString() == type)
                {
                    this.LocationType = locType;
                }
            }
        }

        public Location(string name, LocationType type)
            : base(name)
        {
            this.LocationType = type;
        }
    }
}

namespace TradeAndTravel
{
    public enum LocationType
    {
        Mine,
        Town,
        Forest,
    }
}

namespace TradeAndTravel
{
    public class Merchant:Shopkeeper,ITraveller
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }

        public override int CalculateSellingPrice(Item item)
        {
            if (item == null) return 0;
            else return item.Value;
        }

        public override int CalculateBuyingPrice(Item item)
        {
            if (item == null) return 0;
            else return item.Value / 2;
        }
    }
}

namespace TradeAndTravel
{
    public class Mine:Location
    {
        public Mine(string name)
            : base(name, LocationType.Mine)
        {
        }
    }
}

namespace TradeAndTravel
{
    public class Person : WorldObject
    {
        HashSet<Item> inventoryItems;

        public Location Location { get; protected set; }

        public Person(string name, Location location)
            : base(name)
        {
            this.Location = location;
            this.inventoryItems = new HashSet<Item>();
        }

        public void AddToInventory(Item item)
        {
            this.inventoryItems.Add(item);
        }

        public void RemoveFromInventory(Item item)
        {
            this.inventoryItems.Remove(item);
        }

        public List<Item> ListInventory()
        {
            List<Item> items = new List<Item>();
            foreach (var item in this.inventoryItems)
            {
                items.Add(item);
            }

            return items;
        }
    }
}

namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {
            //var engine = new Engine(new InteractionManager());
            var engine = new Engine(new ExtendedInteractionManager());
            engine.Start();
        }
    }
}

namespace TradeAndTravel
{
    public class Shopkeeper : Person, IShopkeeper
    {
        public Shopkeeper(string name, Location location)
            : base(name, location)
        {
        }

        public virtual int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public virtual int CalculateBuyingPrice(Item item)
        {
            return item.Value / 2;
        }
    }
}

namespace TradeAndTravel
{
    public class Town : Location
    {
        public Town(string name)
            : base(name, LocationType.Town)
        {
        }
    }
}

namespace TradeAndTravel
{
    public class Traveller : Person, ITraveller
    {
        public Traveller(string name, Location location)
            : base(name, location)
        {
        }

        public virtual void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}

namespace TradeAndTravel
{
    public class Weapon:Item
    {
        const int GeneralWeaponValue = 10;

        public Weapon(string name, Location location)
            : base(name, Weapon.GeneralWeaponValue, ItemType.Weapon, location)
        {
        }

    }
}

namespace TradeAndTravel
{
    public class Wood:Item
    {
        const int GeneralWoodValue = 2;

        public Wood(string name, Location location)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (this.Value > 0 && interaction == "drop") this.Value--;
        }
    }
}

namespace TradeAndTravel
{
    public abstract class WorldObject
    {
        static readonly Random random = new Random();
        public string Id { get; private set; }
        private const int IdLength = 128;
        private const string IdChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789_";
        private static HashSet<string> allObjectIds = new HashSet<string>();

        public string Name { get; protected set; }

        protected WorldObject(string name = "")
        {
            this.Name = name;
            this.Id = WorldObject.GenerateObjectId();
        }

        public static string GenerateObjectId()
        {

            StringBuilder resultBuilder = new StringBuilder();
            string result;

            do
            {
                for (int i = 0; i < WorldObject.IdLength; i++)
                {
                    resultBuilder.Append(IdChars[random.Next(0, WorldObject.IdChars.Length)]);
                }

                result = resultBuilder.ToString();
            }
            while (allObjectIds.Contains(result));

            return result;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as WorldObject).Id);
        }
    }
}
