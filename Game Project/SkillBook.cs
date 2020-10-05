using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Project
{

    static public class HeroSkillBook
    {
        public static void HeroUseAttackSingleSkill(Enemy enemy, Hero Hero, string skill)
        {
            int damage = 0;
            string useSkill = skill;
            if (useSkill.Contains("Batarang"))
            {
                damage = Batarang(enemy, Hero);
                enemy.TakeDamage(damage);
            }
            if (useSkill.Contains("Poison Dart"))
            {
                damage = PoisonDart(enemy, Hero);
                enemy.TakeDamage(damage);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{enemy.Name} has been poisoned");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                enemy.PoisonDamage = damage;
                enemy.Poisoned = true;
                enemy.PoisonCounter = 5;
            }
        }
        public static void HeroUseAttackAllSkill(Hero Hero, string skill)
        {
            Console.Clear();
            int damage = 0;
            string useSkill = skill;
            //Nightwing Skills
            if (useSkill.Contains("Shark Repellent"))
            {
                damage = SharkRepellent(Hero);
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

            //Batwoman Skills
            if (useSkill.Contains("Red Knight One"))
            {
                damage = SummonRK1(Hero);
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
        }        
        //Nightwing Skills
        public static int SharkRepellent(Hero Hero)
        {
            GameLogic._heroes[0].Energy -= 20;
            Console.WriteLine($"That's not a shark!!! {Hero.Name} sprays Shark Repellent wildly. It goes in everyones' eyes! ARGHHHHHHH!!!!!");
            Thread.Sleep(1500);
            return Hero.Intelligence;
        }
        public static int Batarang(Enemy enemy, Hero Hero)
        {
            Hero.Energy -= 20;
            Console.WriteLine($"{Hero.Name} thows a Batarang at {enemy.Name}'s face! TWAK!!");
            Thread.Sleep(1500);
            return Hero.Strength + 5;
        }
        

        //Batwoman Skills
        public static int SummonRK1(Hero Hero)
        {
            Hero.Energy -= 35;
            Console.WriteLine($"You hear the roar of an engine! {Hero.Name}'s trusty motorcycle opens fire.");
            return Hero.Intelligence;
        }
        public static int PoisonDart(Enemy enemy, Hero Hero)
        {
            Hero.Energy -= 20;
            Console.WriteLine($"{Hero.Name} fires a wrist-mounted poison dart at {enemy.Name}. TWOOP!");
            Thread.Sleep(1500);
            return Hero.Intelligence/2;
        }
    }
    static public class EnemySkillBook
    {
        public static void EnemyUseAttackSingleSkill(Enemy enemy, Hero Hero, string skill)
        {
            int damage = 0;
            string useSkill = skill;
            if (useSkill.Contains("Tackle"))
            {
                damage = Tackle(enemy, Hero);
                Hero.TakeDamage(damage);
            }
            if (useSkill.Contains("Poison Strike"))
            {
                damage = PoisonStrike(enemy, Hero);
                Hero.TakeDamage(damage);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Hero.Name} has been poisoned");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Hero.PoisonDamage = damage;
                Hero.Poisoned = true;
                Hero.PoisonCounter = 5;
            }
        }
        public static int Tackle(Enemy enemy, Hero Hero)
        {
            Console.Clear();
            Console.WriteLine($"{enemy.Name} viciously tackles {Hero.Name}! THUD!!");
            Thread.Sleep(1500);
            return (int)(enemy.Strength * 1.5);
        }
        public static int PoisonStrike(Enemy enemy, Hero Hero)
        {
            Console.Clear();
            Console.WriteLine($"{enemy.Name} strikes {Hero.Name} with a poison coated blade");
            Thread.Sleep(1500);
            return enemy.Intelligence/2;
        }
    }
}
