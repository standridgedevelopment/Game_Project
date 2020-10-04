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
            double damage = 0;
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
                enemy.PoisonDamge = damage;
                enemy.Poisoned = true;
                enemy.PoisonCounter = 5;
            }
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
        public static double SharkRepellent(Hero Hero)
        {
            GameLogic._heroes[0].Energy -= 20;
            Console.WriteLine($"That's not a shark!!! {Hero.Name} sprays Shark Repellent wildly. It goes in everyones' eyes! ARGHHHHHHH!!!!!");
            Thread.Sleep(1500);
            return Hero.Intelligence;
        }
        public static double Batarang(Enemy enemy, Hero Hero)
        {
            Hero.Energy -= 20;
            Console.WriteLine($"{Hero.Name} thows a Batarang at {enemy.Name}'s face! TWAK!!");
            Thread.Sleep(1500);
            return Hero.Strength + 5;
        }
        

        //Batwoman Skills
        public static double SummonRK1(Hero Hero)
        {
            Hero.Energy -= 35;
            Console.WriteLine($"You hear the roar of an engine! {Hero.Name}'s trusty motorcycle opens fire.");
            return Hero.Intelligence;
        }
        public static double PoisonDart(Enemy enemy, Hero Hero)
        {
            Hero.Energy -= 20;
            Console.WriteLine($"{Hero.Name} fires a wrist-mounted poison dart at {enemy.Name}. TWOOP!");
            Thread.Sleep(1500);
            return Hero.Intelligence/2;
        }
    }
}
