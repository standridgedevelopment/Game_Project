using DocumentFormat.OpenXml.Presentation;
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
        public static Random randomNum = new Random();
        public static List<IItem> Inventory = new List<IItem>();
        static List<Enemy> _areaEnemies = new List<Enemy>();
        public static List<Enemy> _currentEnemies = new List<Enemy>();
        public static List<Hero> _heroes = new List<Hero>();
        static double experienceForFight;
        static int moneyForFight;
        static int enemiesDefeated;
        public static int Money;


        public static void AddAreaEnemy(Enemy enemyType)
        {
            if (enemyType.GetType() == typeof(PenguinThug))
            {
                var PenguinT1 = new PenguinThug(randomNum.Next(1, 4));
                Thread.Sleep(100);
                var PenguinT2 = new PenguinThug(randomNum.Next(1, 4));
                Thread.Sleep(100);
                var PenguinT3 = new PenguinThug(randomNum.Next(1, 4));
                Thread.Sleep(100);
                var PenguinT4 = new PenguinThug(randomNum.Next(1, 4));
                Thread.Sleep(100);
                _areaEnemies.Add(PenguinT1);
                _areaEnemies.Add(PenguinT2);
                _areaEnemies.Add(PenguinT3);
                _areaEnemies.Add(PenguinT4);
            }
        }
        public static void AddCurrentEnemy(Enemy enemy)
        {
            _currentEnemies.Add(enemy);
            _areaEnemies.Remove(enemy);
        }
        public static void AddHero(Hero hero)
        {
            _heroes.Add(hero);
        }
        public static void NewEnemyEncounter()
        {
            int amountOfEnemies = randomNum.Next(1, 10);
            if (amountOfEnemies <= 2)
            {
                AddCurrentEnemy(_areaEnemies[randomNum.Next(0, _areaEnemies.Count)]);
            }
            else if (amountOfEnemies <= 7)
            {
                AddCurrentEnemy(_areaEnemies[randomNum.Next(0, _areaEnemies.Count)]);
                AddCurrentEnemy(_areaEnemies[randomNum.Next(0, _areaEnemies.Count)]);
            }
            else
            {
                AddCurrentEnemy(_areaEnemies[randomNum.Next(0, _areaEnemies.Count)]);
                AddCurrentEnemy(_areaEnemies[randomNum.Next(0, _areaEnemies.Count)]);
                AddCurrentEnemy(_areaEnemies[randomNum.Next(0, _areaEnemies.Count)]);
            }
        }
        public static void PenguinEncounter()
        {
            var penguin = new Penguin();
            _currentEnemies.Add(penguin);
            var thug1 = new PenguinThug(5);
            _currentEnemies.Add(thug1);
            var thug2 = new PenguinThug(5);
            _currentEnemies.Add(thug2);
        }
        public static void CombatScene()
        {
            NewEnemyEncounter();
            /*System.Media.SoundPlayer sound =
            new System.Media.SoundPlayer();
            sound.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Battle.wav";
            sound.Load();
            sound.Play();*/
            experienceForFight = 0;
            moneyForFight = 0;
            enemiesDefeated = 0;
            bool combatInProgress = true;
            while (combatInProgress == true)
            {
                IncreaseTurnMeter();
                Thread.Sleep(1000);
                Console.Clear();
                DisplayEnemies();
                DisplayHeroes();
                combatInProgress = CheckForHeroesTurn();
                CheckForEnemiesTurn();
            }
            VictoryScreen(moneyForFight, experienceForFight);

        }
        public static void PenguinBossScene()
        {
            PenguinEncounter();
            /*System.Media.SoundPlayer sound =
            new System.Media.SoundPlayer();
            sound.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Battle.wav";
            sound.Load();
            sound.Play();*/

            _heroes[0].runAway = false;
            experienceForFight = 0;
            moneyForFight = 0;
            enemiesDefeated = 0;
            bool combatInProgress = true;
            while (combatInProgress == true)
            {
                if (_heroes[0].runAway == true)
                {
                    combatInProgress = false;
                    return;
                }
                IncreaseTurnMeter();
                Thread.Sleep(1000);
                Console.Clear();
                DisplayEnemies();
                DisplayHeroes();
                combatInProgress =  CheckForHeroesTurn();
                CheckForEnemiesTurn();
                //combatInProgress = CheckForEndOfBattle();

            }
            VictoryScreen(moneyForFight, experienceForFight);

        }
        public static void IncreaseTurnMeter()
        {
            foreach (Hero Hero in _heroes)
            {
                Hero.TurnMeter += Hero.Dexterity;
            }
            foreach (Enemy Enemy in _currentEnemies)
            {
                if (Enemy.isDead == false)
                {
                    Enemy.TurnMeter += Enemy.Dexterity;
                }
            }
        }
        public static void CheckForStatusEffectsHeroes()
        {
            foreach (Hero Hero in _heroes)
            {
                if (Hero.Poisoned == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Hero.Name} takes poison damage. OUCH!");
                    Thread.Sleep(500);
                    Hero.TakeDamage(Hero.PoisonDamage);
                    Console.ForegroundColor = ConsoleColor.White;
                    Hero.PoisonCounter -= 1;
                }
            }
        }
        public static void CheckForStatusEffectsEnemy()
        {
            foreach (Enemy enemy in _currentEnemies)
            {
                if (enemy.Poisoned == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{enemy.Name} takes poison damage. OUCH!");
                    Thread.Sleep(500);
                    enemy.TakeDamage(enemy.PoisonDamge);
                    Console.ForegroundColor = ConsoleColor.White;
                    enemy.PoisonCounter -= 1;
                }
            }
        }
        public static void DisplayEnemies()
        {
            int count = 1;
            foreach (var Enemy in _currentEnemies)
            {
                Console.Write($"{count})");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {Enemy.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nHealth: {Enemy.Health} | Level: {Enemy.Level} | Turn Meter: {Enemy.TurnMeter}\n");

                count++;

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
        public static void DisplayHeroes()
        {
            foreach (var Hero in _heroes)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{Hero.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n" +
                    $"Health: {Hero.Health} | Energy: {Hero.Energy} | Turn Meter: {Hero.TurnMeter}");
                Console.WriteLine();
                //count++;
            }

        }
        public static void DisplayHeroesForTarget()
        {
            int count = 1;
            foreach (var Hero in _heroes)
            {
                Console.Write($"{count}) ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{Hero.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n" +
                    $"Health: {Hero.Health} | Energy: {Hero.Energy} | Turn Meter: {Hero.TurnMeter}");
                Console.WriteLine();
                count++;
            }

        }
        public static void DisplayActiveTurnHero(Hero Hero)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Hero.Name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n" +
                    $"Health: {Hero.Health} | Energy: {Hero.Energy} | Turn Meter: {Hero.TurnMeter}");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Batskill");
            Console.WriteLine("3. Item");
            Console.WriteLine("4. Run\n");
            Console.WriteLine("What action do you want to perform?");
        }
        public static bool CheckForHeroesTurn()
        {
            bool combatInProgress = true;
            foreach (Hero Hero in _heroes)
            {
                if (Hero.TurnMeter >= 50)
                {
                    Hero.TurnMeter = 0;
                    HeroTakeTurn(Hero);
                    CheckForStatusEffectsHeroes();
                }
                combatInProgress = CheckForEndOfBattle();
                if (Hero.runAway == true)
                {
                    combatInProgress = false;
                }
                if (combatInProgress == false)
                {
                    return combatInProgress;
                }
            }
            return combatInProgress;
           
        }
        public static void CheckForEnemiesTurn()
        {
            foreach (var enemy in _currentEnemies)
            {
                if (enemy.TurnMeter >= 100)
                {
                    enemy.TurnMeter = 0;
                    EnemyTakeTurn(enemy);
                    CheckForStatusEffectsEnemy();
                }
            }
        }
        static void HeroTakeTurn(Hero Hero)
        {
            bool AttackInProgress = true;
            int count;
            while (AttackInProgress == true)
            {
                AttackInProgress = false;
                count = 1;
                Console.Clear();
                DisplayEnemies();
                DisplayActiveTurnHero(Hero);
                string actionChoice = Console.ReadLine().ToLower();
                int enemyChoice = 0;
                Console.Clear();
                switch (actionChoice)
                {
                    case "1":
                        count = 1;
                        //Show Current Enemies
                        DisplayEnemies();

                        //Select Enemy To Target
                        AttackInProgress = ChooseTargetForBasicAttack(Hero);
                        break;
                    case "2":
                       
                        string useSkill = "";
                        
                            useSkill = HeroChooseSkill(Hero);
                            
                            if (useSkill == "")
                            {
                                AttackInProgress = true;
                            }
                        
                        string typeOfSkill = WhatTypeOfSkill(useSkill);
                        switch (typeOfSkill)
                        {
                            case "Attack Single":
                                AttackInProgress = ChooseTargetForAttackSkill(Hero, useSkill);
                                break;
                            case "Attack All":
                                HeroSkillBook.HeroUseAttackAllSkill(Hero, useSkill);
                                break;
                        }
                        break;
                    case "3":
                        int useItem = -1;
                            useItem = HeroChooseItem(Hero);
                            if (useItem == -1)
                            {
                                AttackInProgress = true;
                                break;
                            }
                        AttackInProgress = ChooseTargetForItem(Hero, useItem);
                        break;
                    case "4":
                        Console.WriteLine("You away like a coward");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Hero.runAway = true; ;
                        return;
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
        public static string HeroChooseSkill(Hero Hero)
        {
            string useSkill = "";
            if (Hero.SkillList.Count == 0)
            {
                Console.WriteLine("No skills available. Try leveling up first");
                Console.ReadKey();
                return useSkill;
            }
            //Show Current Enemies
            DisplayEnemies();
            Console.WriteLine("Which skill would you like to use?");
            int skillCount = 1;
            foreach (var skill in Hero.SkillList)
            {
                Console.WriteLine($"{skillCount}) {skill}");
                skillCount++;
            }
            int skillChoice = 0;
            try
            {
                skillChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            int correctSkillChoice = skillChoice - 1;

            if (correctSkillChoice < Hero.SkillList.Count && correctSkillChoice >= 0)
            {
                useSkill = Hero.SkillList[correctSkillChoice];
                return useSkill;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Select a valid skill.\n" +
                          "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return useSkill;
            }
        }
        public static int HeroChooseItem(Hero Hero)
        {
            int useItem = -1;
            if (InventorySystem.InventoryRecords.Count == 0)
            {
                Console.WriteLine("No items available! Go buy some you cheapskate.");
                Console.ReadKey();
                return useItem;
            }
            //Show Heroes
            DisplayHeroesForTarget();
            Console.WriteLine("Which item would you like to use?");
            int itemCount = 1;
            foreach (var item in InventorySystem.InventoryRecords)
            {
                Console.WriteLine($"{itemCount}) {item.InventoryItem.CombatName}");
                itemCount++;
            }

            int itemChoice = 0;
            try
            {
                itemChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            //if (itemChoice == 1) itemChoice = indexOfFirstAidKit;

            int correctItemChoice = itemChoice - 1;

            if (correctItemChoice < InventorySystem.InventoryRecords.Count && correctItemChoice >= 0)
            {
                useItem = correctItemChoice;
                    //InventorySystem.InventoryRecords[correctItemChoice].InventoryItem.CombatName;
                return useItem;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Select a valid item.\n" +
                          "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return useItem;
            }
        }
        public static string WhatTypeOfSkill(string useSkill)
        {
            string result = "";
            if (useSkill.Contains("Attack All"))
            {
                result = "Attack All";
            }
            if (useSkill.Contains("Attack Single"))
            {
                result = "Attack Single";
            }
            return result;

        }
        public static bool ChooseTargetForBasicAttack(Hero Hero)
        {
            Console.Clear();
            DisplayEnemies();
            Console.WriteLine("Which enemy would you like to attack?");
            Console.WriteLine($"Enter {_currentEnemies.Count + 1} to cancel attack");
            bool AttackInProgress;
            int enemyChoice = 0;
            try
            {
                enemyChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
            }
            int correctEnemyChoice = enemyChoice - 1;
            if (correctEnemyChoice < 0)
            {
                correctEnemyChoice = 5;
            }
            if (enemyChoice == _currentEnemies.Count + 1)
            {
                return AttackInProgress = true;


            }
            if (correctEnemyChoice < _currentEnemies.Count)
            {
                if (_currentEnemies[correctEnemyChoice].isDead == true)
                {
                    Console.WriteLine("They're aleady unconcious.\n" +
                    "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return AttackInProgress = true;
                }

            }

            //Attack
            if (correctEnemyChoice >= 0 && correctEnemyChoice < _currentEnemies.Count)
            {
                Console.Clear();
                double damage = Hero.BasicAttack(_currentEnemies[correctEnemyChoice]);
                _currentEnemies[correctEnemyChoice].TakeDamage(damage);
                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(2000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option.\n" +
                            "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return AttackInProgress = true;
            }
            return AttackInProgress = false;
        }
        public static bool ChooseTargetForAttackSkill(Hero Hero, string useSkill)
        {
            bool AttackInProgress;
            Console.Clear();
            int count = 1;
            DisplayEnemies();
            Console.WriteLine("\nWhich enemy would you like to target?");
            Console.WriteLine($"Enter {_currentEnemies.Count + 1} to cancel attack");
            //Select Enemy To Target
            int enemyChoice = 0;
            try
            {
                enemyChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            int correctEnemyChoice;
            correctEnemyChoice = enemyChoice - 1;
            if (correctEnemyChoice < 0)
            {
                correctEnemyChoice = 5;
            }

            if (enemyChoice == _currentEnemies.Count + 1)
            {
                return AttackInProgress = true;
            }
            if (correctEnemyChoice < _currentEnemies.Count)
            {
                if (_currentEnemies[correctEnemyChoice].isDead == true)
                {
                    Console.WriteLine("They're aleady unconcious.\n" +
                           "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return AttackInProgress = true;
                }

            }

            //Attack
            if (correctEnemyChoice >= 0 && correctEnemyChoice < _currentEnemies.Count)
            {
                Console.Clear();
                HeroSkillBook.HeroUseAttackSingleSkill(_currentEnemies[correctEnemyChoice], Hero, useSkill);
                Thread.Sleep(2000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option.\n" +
                            "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return AttackInProgress = true;
            }
            return AttackInProgress = false;
        }
        public static bool ChooseTargetForItem(Hero Hero, int useItem)
        {
            bool AttackInProgress;
            Console.Clear();
            int count = 1;
            DisplayHeroesForTarget();
            Console.WriteLine("\nWhich Hero would you like to target?");
            Console.WriteLine($"Enter {_heroes.Count + 1} to cancel attack");
            //Select Enemy To Target
            int heroChoice = 0;
            try
            {
                heroChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            int correctHeroChoice;
            correctHeroChoice = heroChoice - 1;
            if (correctHeroChoice < 0)
            {
                correctHeroChoice = 5;
            }

            if (heroChoice ==_heroes.Count + 1)
            {
                return AttackInProgress = true;
            }
            if (correctHeroChoice < _heroes.Count)
            {
                if (_currentEnemies[correctHeroChoice].isDead == true)
                {
                    Console.WriteLine("They're unconcious.\n" +
                           "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return AttackInProgress = true;
                }

            }

            //Use Item
            if (correctHeroChoice >= 0 && correctHeroChoice < _heroes.Count)
            {
                Console.Clear();
                InventorySystem.InventoryRecords[useItem].InventoryItem.UseItem(_heroes[correctHeroChoice], InventorySystem.InventoryRecords[useItem].InventoryItem);
                Thread.Sleep(2000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option.\n" +
                            "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return AttackInProgress = true;
            }
            return AttackInProgress = false;
        }
        static void EnemyTakeTurn(Enemy enemy)
        {
            int heroTarget = randomNum.Next(0, _heroes.Count);
            //Hero target = _heroes[heroTarget];
            int chooseAttack = randomNum.Next(1, 2);
            switch (chooseAttack)
            {
                case 1:
                    //enemy.Attack(target);
                    double damage = enemy.BasicAttack();

                    Console.Clear();
                    Console.WriteLine($"{enemy.Name} hits {_heroes[heroTarget].Name} in the knees! POW!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Thread.Sleep(200);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    _heroes[heroTarget].TakeDamage(damage);

                    Thread.Sleep(2000);
                    break;

                default:
                    break;
            }
        }
        static bool CheckForEndOfBattle()
        {
            bool combatInProgress = true;
            foreach (var Enemy in _currentEnemies)
            {
                if (Enemy.isDead == true && Enemy.Rewards == false)
                {
                    experienceForFight += Enemy.WorthXP;
                    moneyForFight += Enemy.Money;
                    Enemy.Rewards = true;
                    enemiesDefeated += 1;
                }
                if (enemiesDefeated == _currentEnemies.Count)
                {
                    combatInProgress = false;
                }
            }
            return combatInProgress;
        }
        static void VictoryScreen(int moneyForFight, double experienceForFight)
        {
            Console.Clear();
            /*System.Media.SoundPlayer sound2 =
            new System.Media.SoundPlayer();
            sound2.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Victory.wav";
            sound2.Load();
            sound2.Play();*/
            Money += moneyForFight;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"${moneyForFight} recieved.");
            Thread.Sleep(500);

            _currentEnemies.Clear();
            _areaEnemies.Clear();
            foreach (var Hero in _heroes)
            {
                Hero.runAway = false;
                Hero.Poisoned = false;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{Hero.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" has recieved {experienceForFight} experience.");
                Thread.Sleep(500);
                Hero.XP += experienceForFight;
                if (Hero.XP > 0)
                {
                    Console.WriteLine($"{Hero.Name} needs {Hero.xpForLevelUp - Hero.XP} experience for next level");
                }
                Thread.Sleep(500);
                Console.WriteLine("\nPress any key to continue...");

                Console.ReadKey();
                Console.Clear();
            }
        }


    }

}
