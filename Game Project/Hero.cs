using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Game_Project
{
    public abstract class Hero
    {
        public string Name;
        public double MaxHealth
        {
            get => Vitality * 10;
        }
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
        public int MaxEnergy
        {
            get => Intelligence * 10;
        }
        private int _energy;
        public int Energy
        {
            get { return _energy; }
            set
            {
                if (value >= MaxEnergy)
                {
                    _energy = MaxEnergy;
                }
                else if (value <= 0)
                {
                    _energy = 0;
                }
                else _energy = value;
            }
        }
        public int Strength;
        public int Dexterity;
        public int Vitality;
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
        private double _xp;
        public double XP
        {
            get { return _xp; }
            set
            {
                if (value >= xpForLevelUp)
                {
                    LevelUP();
                    _xp = 0;
                }
                else _xp = value;
            }
        }
        public double xpForLevelUp;
        public List<string> SkillList = new List<string>();
        public List<Action> SkillsUse = new List<Action>();
        public int SkillNumber;
        public string SuperHeroName;
        public virtual void AddSkill(string FullNameOfSkill)
        {
        }
        
        public virtual void LevelUP()
        {
            
        }
        public double BasicAttack(Enemy enemy)
        {
            Console.WriteLine($"{Name} punches {enemy.Name} in the face. POW!");
            Thread.Sleep(1000);
            return Strength;
        }
        public void TakeDamage(double damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage!");
            Thread.Sleep(800);
        }
        public bool runAway;
       
    }
    public class Nightwing : Hero
    {
        public override void LevelUP()
        {
            Level += 1;
            Console.WriteLine($"\n{Name} has leveled up!!");
            Random statsIncrease = new Random();
            int strengthIncrease = statsIncrease.Next(1, 5);
            Strength += strengthIncrease;
            Console.WriteLine($"+{strengthIncrease} Strength");
            int vitalityIncrease = statsIncrease.Next(1, 4);
            Vitality += vitalityIncrease;
            Console.WriteLine($"+{vitalityIncrease} Vitality");
            int intelligenceIncrease = statsIncrease.Next(1, 3);
            Intelligence += intelligenceIncrease;
            Console.WriteLine($"+{intelligenceIncrease} Intelligence");
            int dexterityIncrease = statsIncrease.Next(1, 3);
            Dexterity += dexterityIncrease;
            Console.WriteLine($"+{dexterityIncrease} Dexterity");
            
            
        }
        public Nightwing()
        {
            Level = 1;
            xpForLevelUp = 70 + (Level * 30);
            Vitality = 15;
            Health = MaxHealth;
            Intelligence = 5;
            Energy = MaxEnergy;
            Strength = 15;
            Dexterity = 12;
            TurnMeter = 0;
            Name = "Nightwing";
            runAway = false;
            new List<string>();
            new List<Action>();
            AddSkill($"Shark Repelent (Attack All) (20)");
            AddSkill($"Batarang (Attack Single) (20)");
        }
        public double SharkRepelent() 
        {
            Energy -= 20;
            Console.WriteLine($"That's not a shark!!! You spray Shark Repelent wildly. It goes in everyones' eyes! ARGHHHHHHH!!!!!");
            Thread.Sleep(1500);
            return Intelligence;
        }
        public double Batarang(Enemy enemy)
        {
            Energy -= 20;
            Console.WriteLine($"Nightwing thows a Batarang at {enemy.Name}'s face! TWAK!!");
            Thread.Sleep(1500);
            return Strength + 5;
        }
        public override void AddSkill(string FullNameOfSkill)
        {
            SkillList.Add(FullNameOfSkill);
            int skillNumber = (SkillList.IndexOf(FullNameOfSkill) + 1);
        }
      

       

    }
    public class Batwoman : Hero
    {
        public override void LevelUP()
        {
            Level += 1;
            Console.WriteLine($"\n{Name} has leveled up!!");
            Random statsIncrease = new Random();
            int strengthIncrease = statsIncrease.Next(1, 3);
            Strength += strengthIncrease;
            Console.WriteLine($"+{strengthIncrease} Strength");
            int vitalityIncrease = statsIncrease.Next(1, 3);
            Vitality += vitalityIncrease;
            Console.WriteLine($"+{vitalityIncrease} Vitality");
            int intelligenceIncrease = statsIncrease.Next(1, 5);
            Intelligence += intelligenceIncrease;
            Console.WriteLine($"+{intelligenceIncrease} Intelligence");
            int dexterityIncrease = statsIncrease.Next(0, 3);
            Dexterity += dexterityIncrease;
            Console.WriteLine($"+{dexterityIncrease} Dexterity");

        }
        public double SummonRK1()
        {
            Energy -= 35;
            Console.WriteLine($"You hear the roar of an engine! Your trusty motorcycle attacks everyone.");
            return Intelligence;
        }
        public Batwoman()
        {
            Level = 3;
            xpForLevelUp = 70 + (Level * 30);
            Vitality = 16;
            Health = MaxHealth;
            Intelligence = 19;
            Energy = MaxEnergy;
            Strength = 14;
            Dexterity = 20;
            TurnMeter = 0;
            Name = "Batwoman";
            new List<string>();
            SkillList.Add("Summon Red Knight One (Attack All) (35)");
        }

    }

}
