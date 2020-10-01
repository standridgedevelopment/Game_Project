using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Project
{
    public class KeyValuePair<TKey, TValue>
    {
        public TKey key;
        public TValue value;

        public KeyValuePair (TKey _key, TValue _value)
        {
            key = _key;
            value = _value;
        }
    }
    static public class HeroSkillBook
    {
        public static double HeroUseAttackSingleSkill(Enemy enemy, Hero Hero, string skill)
        {
            double damage = 0;
            string useSkill = skill;
            if (useSkill.Contains("Batarang"))
            {
                damage = Batarang(enemy, Hero);
            }
            return damage;
        }
        public static void HeroUseAttackAllSkill(Hero Hero, string skill)
        {
            Console.Clear();
            double damage = 0;
            string useSkill = skill;
            //Nightwing Skills
            if (useSkill.Contains("Shark Repellent"))
            {
                damage = SharkRepellent(Hero);
            }

            //Batwoman Skills
            if (useSkill.Contains("Red Knight One"))
            {
                damage = SummonRK1(Hero);
            }


            foreach (Enemy enemy in GameLogic._currentEnemies)
            {
                if (enemy.isDead == false)
                {
                    enemy.TakeDamage(damage);
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(2000);
                }
            }


        }
        //public static KeyValuePair<string, double> NightwingSkills = new KeyValuePair<string, double>("Shark Repelent",SharkRepelent());
        
        //Nightwing Skills
        public static double SharkRepellent(Hero Hero)
        {
            GameLogic._heroes[0].Energy -= 20;
            Console.WriteLine($"That's not a shark!!! You spray Shark Repellent wildly. It goes in everyones' eyes! ARGHHHHHHH!!!!!");
            Thread.Sleep(1500);
            return Hero.Intelligence;
        }
        public static double Batarang(Enemy enemy, Hero Hero)
        {
            Hero.Energy -= 20;
            Console.WriteLine($"Nightwing thows a Batarang at {enemy.Name}'s face! TWAK!!");
            Thread.Sleep(1500);
            return Hero.Strength + 5;
        }

        //Batwoman Skills
        public static double SummonRK1(Hero Hero)
        {
            Hero.Energy -= 35;
            Console.WriteLine($"You hear the roar of an engine! Your trusty motorcycle attacks everyone.");
            return Hero.Intelligence;
        }
    }
}
