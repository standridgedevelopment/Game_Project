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
        static Random randomNum = new Random();
        static List<Enemy> _areaEnemies = new List<Enemy>();
        static List<Enemy> _currentEnemies = new List<Enemy>();
        static List<Hero> _heroes = new List<Hero>();
        static int Money = 0;


        public static void AddAreaEnemy(Enemy enemyType)
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
        public static void NewEnemyEncounter()
        {
            PenguinThug enemy1 = new PenguinThug(randomNum.Next(1, 4));
            Thread.Sleep(200);
            PenguinThug enemy2 = new PenguinThug(randomNum.Next(1, 4));
            Thread.Sleep(200);
            PenguinThug enemy3 = new PenguinThug(randomNum.Next(1, 4));
            int amountOfEnemies = randomNum.Next(2, 4);
            switch (amountOfEnemies)
            {
                case 1:
                    _currentEnemies.Add(enemy1);
                    break;
                case 2:
                    _currentEnemies.Add(enemy1);
                    _currentEnemies.Add(enemy2);
                    break;
                case 3:
                    _currentEnemies.Add(enemy1);
                    _currentEnemies.Add(enemy2);
                    _currentEnemies.Add(enemy3);
                    break;
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
        public static void DisplayEnemies()
        {
            int count = 1;
            foreach (var Enemy in _currentEnemies)
            {
                if (Enemy.isDead == false)
                {
                    Enemy.TurnMeter += Enemy.Dexterity;
                }
                Console.Write($"{count})");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {Enemy.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");

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
                Hero.TurnMeter += Hero.Dexterity;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{Hero.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n" +
                    $"Health: {Hero.Health} | Energy: {Hero.Energy} | Turn Meter: {Hero.TurnMeter}");
                Console.WriteLine();
                //count++;
            }

        }
        public static void CheckForHeroesTurn()
        {
            if (_heroes[0].TurnMeter >= 75)
            {
                _heroes[0].TurnMeter = 0;
                HeroTakeTurn(_heroes[0]);
            }
            if (_heroes[_heroes.Count - 1].TurnMeter >= 75)
            {
                _heroes[_heroes.Count - 1].TurnMeter = 0;
                HeroTakeTurn(_heroes[_heroes.Count - 1]);

            }
        }
        public static void CheckForEnemiesTurn()
        {
            foreach (var enemy in _currentEnemies)
            {
                if (enemy.TurnMeter >= 100)
                {
                    enemy.TurnMeter = 0;
                    EnemyTakeTurn(enemy);
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
                /*foreach (var Enemy in _currentEnemies)
                {
                    Console.Write($"{count})");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($" {Enemy.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");
                    count++;
                }*/
            
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{Hero.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n" +
                        $"Health: {Hero.Health} | Energy: {Hero.Energy} | Turn Meter: {Hero.TurnMeter}");
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
                        DisplayEnemies();
                        Console.WriteLine("Which enemy would you like to attack?");
                        Console.WriteLine($"Enter {_currentEnemies.Count +1} to cancel attack");
                        //Select Enemy To Target
                        AttackInProgress = ChooseTargetForBasicAttack(Hero);
                        /*try
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
                            AttackInProgress = true;
                        }
                        int correctEnemyChoice = enemyChoice - 1;
                        if (correctEnemyChoice < 0)
                        {
                            correctEnemyChoice = 5;
                        }
                        if (enemyChoice == _currentEnemies.Count + 1)
                        {
                            AttackInProgress = true;
                            break;

                        }
                        if (correctEnemyChoice < _currentEnemies.Count)
                        {
                            if (_currentEnemies[correctEnemyChoice].isDead == true)
                            {
                                Console.WriteLine("They're aleady unconcious.\n" +
                                "Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                AttackInProgress = true;
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
                            AttackInProgress = true;
                        }*/

                        break;
                    case "2":
                        bool chooseSkill = false;
                        string useSkill = "";
                        while (chooseSkill == false)
                        {
                            chooseSkill = true;
                            count = 1;
                            //Show Current Enemies
                            foreach (var Enemy in _currentEnemies)
                            {
                                Console.Write($"{count})");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($" {Enemy.Name}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");
                                count++;

                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
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
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Select a valid skill.\n" +
                                          "Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                chooseSkill = false;
                            }
                        }
                        Console.Clear();
                        count = 1;
                        foreach (var Enemy in _currentEnemies)
                        {
                            Console.Write($"{count})");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {Enemy.Name}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"\nHealth: {Enemy.Health} | Turn Meter: {Enemy.TurnMeter}\n");
                            count++;

                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\nWhich enemy would you like to target?");
                        Console.WriteLine($"Enter {count} to cancel attack");
                        //Select Enemy To Target
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

                        if (enemyChoice == count)
                        {
                            AttackInProgress = true;
                            break;
                        }
                        if (correctEnemyChoice < _currentEnemies.Count)
                        {
                            if (_currentEnemies[correctEnemyChoice].isDead == true)
                            {
                                Console.WriteLine("They're aleady unconcious.\n" +
                                       "Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                chooseSkill = false;
                            }

                        }

                        //Attack
                        if (correctEnemyChoice >= 0 && correctEnemyChoice < _currentEnemies.Count)
                        {
                            double damage = 0;
                            Console.Clear();
                            //Enemy target = _currentEnemies[correctEnemyChoice];
                            if (useSkill == "Shark Repelent (20)")
                            {
                                Nightwing hero = (Nightwing)Hero;
                                damage = hero.SharkRepelent(_currentEnemies[correctEnemyChoice]);
                                Thread.Sleep(1000);
                                _currentEnemies[correctEnemyChoice].TakeDamage(damage);
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            if (useSkill == "Summon Red Knight One (35)")
                            {
                                Batwoman hero = (Batwoman)Hero;
                                damage = hero.SummonRK1(_currentEnemies[correctEnemyChoice]);
                                Thread.Sleep(1000);
                                foreach (Enemy enemy in _currentEnemies)
                                {
                                    if (enemy.isDead == false)
                                    {
                                        enemy.TakeDamage(damage);
                                        Thread.Sleep(500);
                                        Console.WriteLine();
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.White;

                            }


                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid option.\n" +
                                        "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            AttackInProgress = true;
                        }
                        break;
                    case "3":
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
        public static bool ChooseTargetForBasicAttack(Hero Hero)
        {
            Console.Clear();
            DisplayEnemies();
            Console.WriteLine("Which enemy would you like to attack?");
            Console.WriteLine($"Enter {_currentEnemies.Count + 1} to cancel attack");
            bool AttackInProgress = false;
            int enemyChoice = 0;
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
            foreach (var Hero in _heroes)
            {
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
                Console.WriteLine("Press any key to continue...");

                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void CombatScene()
        {
            /*System.Media.SoundPlayer sound =
            new System.Media.SoundPlayer();
            sound.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Battle.wav";
            sound.Load();
            sound.Play();*/

            _heroes[0].runAway = false;
            double experienceForFight = 0;
            int moneyForFight = 0;
            int count = 0;
            bool combatInProgress = true;
            int enemiesDefeated = 0;
                while (combatInProgress == true)
                {
                    if (_heroes[0].runAway == true)
                    {
                        combatInProgress = false;
                        return;
                    }
                Thread.Sleep(1000);
                count = 1;
                Console.Clear();
                DisplayEnemies();
                DisplayHeroes();
                CheckForHeroesTurn();
                CheckForEnemiesTurn();
                   
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
                }
            VictoryScreen(moneyForFight, experienceForFight);

        }

    }

}
