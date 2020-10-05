using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Project
{

     public abstract class Enemy
        {
        public Random randomStats = new Random();
        public string Name;
        public int MaxHealth;
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                if (value >= MaxHealth)
                {
                    _health = MaxHealth;
                }
                else if (value <= 0)
                {
                    _health = 0;
                }
                else _health = value;
            }
        }
        public int Strength;
        public int Armor;
        public int Intelligence;
        public int Level;
        public int _turnMeter;
        public int TurnMeter
        {
            get { return _turnMeter; }
            set
            {
                if (value >= 100)
                {
                    _turnMeter = 100;
                }
                _turnMeter = value;
            }
        }
        public List<string> SkillList = new List<string>();
        public int Dexterity;
        public int Money;
        public int WorthXP;
        public List<string> Loot = new List<string>();
        public bool isDead;
        public bool Rewards;
        public bool Poisoned;
        public int PoisonCounter;
        public int PoisonDamage;
      
        public virtual void BasicAttack(Hero Hero)
        {
            Console.Clear();
            Console.WriteLine($"{Name} hits {Hero.Name} in the knees! POW!");
            Thread.Sleep(1200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Hero.TakeDamage(Strength);
   
        }
        public void TakeDamage(int damage)
        {
            Thread.Sleep(500);
            Health -= damage;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"{Name} takes {damage} damage!");
            Thread.Sleep(400);
            if (Health <= 0)
            {
                isDead = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} is knocked out.");
            }
        }
       

    }
    public class PenguinThug : Enemy
    { 
        public PenguinThug(int level)
        
        {
            Level = level;
            Name = "Penguin Thug";
            MaxHealth = randomStats.Next(10,20) + (randomStats.Next(1,5)*level); //20, 30
            Health = MaxHealth;
            TurnMeter = 0;
            Dexterity = randomStats.Next(8,12) + (randomStats.Next(1, 4) * level); //20, 30;
            Strength = randomStats.Next(8,12) + (randomStats.Next(1, 4) * level); //20, 30)
            Intelligence = randomStats.Next(6, 10) + (randomStats.Next(1, 5) * level); //20, 30
            Money = 50 + (10 * level);
            WorthXP = 30 + (5 * level);
            isDead = false;
            Rewards = false;
            new List<string>();
            new List<string>();
            Loot.Add("First Aid Kit");
            SkillList.Add("Tackle (Single)");
        }
        public override void BasicAttack(Hero Hero)
        {
            Console.Clear();
            Console.WriteLine($"{Name} hits {Hero.Name} in the knees! POW!");
            Thread.Sleep(1200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Hero.TakeDamage(Strength);
        }
        public PenguinThug() {  }
    }
    public class PoisonThug : Enemy
    {
        public override void BasicAttack(Hero Hero)
        {
            Console.Clear();
            Console.WriteLine($"{Name} swipes at {Hero.Name} with a knife! SWISH!!!");
            Thread.Sleep(1200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Thread.Sleep(200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Hero.TakeDamage(Strength);
        }
        public PoisonThug(int level)
        {
            Level = level;
            Name = "Poison Thug";
            MaxHealth = randomStats.Next(10, 20) + (randomStats.Next(1, 5) * level); //20, 30
            Health = MaxHealth;
            TurnMeter = 0;
            Dexterity = randomStats.Next(6, 10) + (randomStats.Next(1, 5) * level); //20, 30;
            Strength = randomStats.Next(6, 10) + (randomStats.Next(1, 5) * level); //20, 30)
            Intelligence = randomStats.Next(6, 10) + (randomStats.Next(1, 5) * level); //20, 30
            Money = 50 + (10 * level);
            WorthXP = 30 + (5 * level);
            isDead = false;
            Rewards = false;
            new List<string>();
            new List<string>();
            SkillList.Add("Poison Strike (Single)");
            Loot.Add("Antitote");
            Loot.Add("First Aid Kit");
        }

    }

    public class Penguin : Enemy
    {
        public Penguin()
        {
            Name = "Penguin";
            MaxHealth = 100;
            Health = MaxHealth;
            TurnMeter = 0;
            Dexterity = 15;
            Strength = 20;
            isDead = false;
            Rewards = false;
        }
    }
}
