using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Project
{
    public static class GameLogic
    {
        static Random randomNum = new Random();
        static List<string> _areaEnemies = new List<string>();
        static List<Enemy> _currentEnemies = new List<Enemy>();
        static List<Hero> _heroes = new List<Hero>();


        public static void AddAreaEnemy(string enemyType)
        {
            _areaEnemies.Add(enemyType);
        }
        public static void EmptyAreaEnemyList()
        {
            foreach (var enemy in _areaEnemies)
            {
                _areaEnemies.Remove(enemy);
            }
        }
        public static void AddCurrentEnemy(Enemy enemy)
        {
            _currentEnemies.Add(enemy);
        }
        public static void AddHero(Hero hero)
        {
            _heroes.Add(hero);
        }
        //Do Damage
        public static void DamageEnemy(Enemy target, int damage)
        {
            Enemy currentEnemy = target;
            currentEnemy.Health -= damage;
        }
        public static void DamageHero(Hero target, int damage)
        {
            Hero currentHero = target;
            currentHero.Health -= damage;
        }
        public static List<Enemy> GetListOfEnemies()
        {
            return _currentEnemies;
        }

        public static void CombatScene()
        {

            List<Enemy> currentEnemies = _currentEnemies;
            List<Hero> Heroes = _heroes;
            int count = 0;
            bool combatInProgress = true;
            while (combatInProgress == true)
            {
                
                Thread.Sleep(1000);
                count = 1;
                Console.Clear();
                foreach (var Enemy in _currentEnemies)
                {
                    Enemy.TurnMeter += Enemy.Dexterity;
                    Console.WriteLine($"{count}) {Enemy.Name}\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                foreach (var Hero in _heroes)
                {
                    Hero.TurnMeter += Hero.Dexterity;
                    Console.WriteLine($"{Hero.Name}\n" +
                        $"Health: {Hero.Health} | Energy: {Hero.Energy} | Turn Meter: {Hero.TurnMeter}");

                    count++;
                }
                foreach (var Hero in _heroes)
                {
                    bool AttackInProgress = true;
                    
                    if (Hero.TurnMeter >= 100)
                    {
                        Hero.TurnMeter = 0;
                        
                        while (AttackInProgress == true)
                        {
                            count = 1;
                            Console.Clear();
                            foreach (var Enemy in _currentEnemies)
                            {

                                Console.WriteLine($"{count}) {Enemy.Name}\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");
                                count++;
                            }
                            AttackInProgress = false;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine($"{Hero.Name}");
                            Console.WriteLine("1. Attack");
                            Console.WriteLine("2. Batskill");
                            Console.WriteLine("3. Run\n");
                            Console.WriteLine("What action do you want to perform?");
                            string actionChoice = Console.ReadLine().ToLower();
                            int enemyChoice = 0;


                            Console.Clear();


                            switch (actionChoice)
                            {
                                case "1":
                                    count = 1;
                                    //Show Current Enemies
                                    foreach (var Enemy in _currentEnemies)
                                    {
                                        
                                        Console.WriteLine($"{count}) {Enemy.Name}\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");
                                        count++;
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Which enemy would you like to attack?\n");
                                    Console.WriteLine($"Type {count} to go back");
                                    //Select Enemy To Target
                                    try
                                    {
                                        enemyChoice = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        /*Console.Clear();
                                        Console.WriteLine("Please enter a number.\n" +
                                                    "Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        AttackInProgress = true;*/
                                    }
                                    int correctEnemyChoice = enemyChoice - 1;

                                    if (enemyChoice == count)
                                    {
                                        AttackInProgress = true;
                                        break;

                                    }
                                    //Attack
                                    else if (correctEnemyChoice >= 0 && correctEnemyChoice < _currentEnemies.Count)
                                    {
                                        Enemy target = _currentEnemies[correctEnemyChoice];
                                        Hero.Attack(target);
                                        Console.Clear();
                                        Console.WriteLine($"Nightwing punches {target.Name} in the face. POW!");
                                        Console.WriteLine($"{target.Name} takes {Hero.Strength} damage!");
                                        Thread.Sleep(2000);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid option.\n" +
                                                    "Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        AttackInProgress = true;
                                    }

                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid option.\n" +
                                                   "Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    AttackInProgress = true;
                                    break;
                            }
                        }


                    }
                }
                foreach (var enemy in _currentEnemies)
                {
                    if (enemy.TurnMeter >= 100)
                    {
                        enemy.TurnMeter = 0;
                        int heroTarget = randomNum.Next(0, _heroes.Count);
                        Hero target = _heroes[heroTarget];
                        int chooseAttack = randomNum.Next(1, 2);
                        switch (chooseAttack)
                        {
                            case 1:
                                enemy.Attack(target);
                                Console.Clear();
                                Console.WriteLine($"{enemy.Name} hits {target.Name} in the knees! POW!");
                                Console.WriteLine($"{target.Name} takes {enemy.Strength} damage!");
                                Thread.Sleep(2000);
                                break;
                                    
                            default:
                                break;
                        }
                    }
                }
               
            }

        }
        static void TakeTurn()
        {

        }
    }


}
