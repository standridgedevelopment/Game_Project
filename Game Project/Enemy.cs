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
        public double MaxHealth;
        private double _health;
        public double Health
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
        public int Dexterity;
        public int Money;
        public int WorthXP;
        public bool isDead;
        public bool Rewards;
      
        public double BasicAttack()
        {
            return Strength;
        }
        public void TakeDamage(double damage)
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
            Thread.Sleep(800);
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
            Name = "Penguin Thug";
            MaxHealth = randomStats.Next(5,10) + (randomStats.Next(0,5)*level); //20, 30
            Health = MaxHealth;
            TurnMeter = 0;
            Dexterity = randomStats.Next(6,10);
            Strength = randomStats.Next(6,10);
            Money = randomStats.Next(50, 100);
            WorthXP = randomStats.Next(20, 30);
            isDead = false;
            Rewards = false;
            Level = level;
        }
    }
    public class Penguin : Enemy
    {
        public Penguin()
        {
            Name = "Penguin";
            MaxHealth = 150;
            Health = MaxHealth;
            TurnMeter = 0;
            Dexterity = 15;
            Strength = 20;
        }
    }
}
