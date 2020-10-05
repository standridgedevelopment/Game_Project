using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Project
{
    public interface IItem
    {
        public string Name { get; set; }
        public string CombatName { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
        public int ID {get; set;}
        public int Quanity { get; set; }
        public void Sell();
        public void UseItem(Hero Hero, IItem item);

    }
    public interface IConsumable
    {
       
    }
    public class FirstAidKit : IItem, IConsumable
    {
        public string Name
        {
            get
            {
                return $"First Aid Kit";
            }
            set { }
        }
        public string CombatName
        {
            get
            {
                return $"First Aid Kit (Recover Slight Health) x{Quanity}";
            }
            set { }
        }
        public int Cost
        {
            get
            {
                return 100;
            }
            set { }
        }
        public int Value
        {
            get
            {
                return 70;
            }
            set { }
        }
        public int ID
        {
            get
            {
                return 1;
            }
            set { }
        }
        public int Quanity { get; set; }
       
        public void Sell()
        {
            Console.WriteLine($"You have sold a {Name} for ${Value}.");
            GameLogic.Money += Value;
            Console.WriteLine($"You now have ${GameLogic.Money}");
        }
        public void UseItem(Hero Hero, IItem item)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Hero.Name} recovers 100 health!");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.White;
            Hero.Health += 80;
            Quanity -= 1;
            if (Quanity <= 0)
            {
                var firstAid = new FirstAidKit();
                InventorySystem.RemoveItem(item);
            }

        }
    }
    public class Antidote : IItem, IConsumable
    {
        public string Name
        {
            get
            {
                return $"Antidote";
            }
            set { }
        }
        public string CombatName
        {
            get
            {
                return $"Antidote (Cure Poison) x{Quanity}";
            }
            set { }
        }
        public int Cost
        {
            get
            {
                return 100;
            }
            set { }
        }
        public int Value
        {
            get
            {
                return 70;
            }
            set { }
        }
        public int ID
        {
            get
            {
                return 2;
            }
            set { }
        }
        public int Quanity { get; set; }
       
        public void Sell()
        {
            Console.WriteLine($"You have sold a {Name} for ${Value}.");
            GameLogic.Money += Value;
            Console.WriteLine($"You now have ${GameLogic.Money}");
        }
        public void UseItem(Hero Hero, IItem item)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Hero.Name} uses antidote!");
            Thread.Sleep(500);
            if (Hero.Poisoned == true)
            {
                Console.WriteLine($"{Hero.Name} is no longer poisoned! Heck yeah!");
            }
            else Console.WriteLine("Antiode had no effect. Bummer!");
            Console.ForegroundColor = ConsoleColor.White;
            Hero.Poisoned = false;
            Quanity -= 1;
            if (Quanity <= 0)
            {
                InventorySystem.RemoveItem(item);
            }

        }
    }
}
