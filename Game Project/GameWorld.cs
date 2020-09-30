using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Project
{
    public class GameWorld
    {
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            /*System.Media.SoundPlayer sound =
            new System.Media.SoundPlayer();
            sound.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Main.wav";
            sound.Load();
            sound.Play();*/
            bool runGame = true;
            while (runGame == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to Gotham Knights\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1: New Game");
                Console.WriteLine("2: Exit\n");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "new game":
                        //Start Game
                        StartGame();
                        break;
                    case "1":
                        //Start Game
                        StartGame();
                        break;
                    case "exit":
                        runGame = false;
                        break;
                    case "2":
                        runGame = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, what did you want to do?\n" +
                            "Press any key to try again...");
                        break;
                }

            }
        }
        public void StartGame()
        {
            bool inGotham = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Batman");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" has been captured. You need to find him.");
            Thread.Sleep(5000);
            Console.Write("You are Batman's apprentice, Dick Grayson. Now known as");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Nightwing!");
            Thread.Sleep(5000);
            var mainPlayer = new Nightwing();
            GameLogic.AddHero(mainPlayer);
            while (inGotham == true)
            {
                /*System.Media.SoundPlayer sound =
                new System.Media.SoundPlayer();
                sound.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Field.wav";
                sound.Load();
                sound.Play();*/
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to Gotham City");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What do you want to do?:\n" +
                                      "1) Visit Lucious Fox for new gear \n" +
                                      "2) Head to the Bat Cave \n" +
                                      "3) Head to the streets to find clues about Batman\n" +
                                      "4) Exit to Title Screen");
                int selection = 0;
                try
                {
                   selection = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number.\n" +
                                         "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                switch (selection)
                {
                    case 1:
                        //Visit Fox
                        Console.Clear();
                        Console.WriteLine("You walk into Wayne Tech and see Lucious Fox working on some new gadgets. " +
                            "\nYou see a new prototype for a motorcycle behind him, thinking it's for you. " +
                            "\nHe hands you an aerosol can and says that's all he has for you today. You turn the can over to read, \"Shark Repellent\".");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        //Batcave
                        Console.Clear();
                        Console.WriteLine("You see Alfred over by the costume cases, dusting. You go and hug him. :)");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Alfred needs hugs too.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        //Patrol Streets
                        PatrolStreets();
                        break;
                    case 4:
                        inGotham = false;
                        return;
                    default:
                        Console.WriteLine("Please make a valid selection\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //Patrol the streets
        private void PatrolStreets()
        {
            bool inStreets = true;
            var enemy1 = new PenguinThug(1);
            var enemy2 = new PenguinThug(2);
            var enemy3 = new PenguinThug(3);
            GameLogic.AddAreaEnemy(enemy1);
            GameLogic.AddAreaEnemy(enemy2);
            GameLogic.AddAreaEnemy(enemy3);
            int searchProgress = 0;
            while (inStreets == true)
                {
                /*System.Media.SoundPlayer sound =
                new System.Media.SoundPlayer();
                sound.SoundLocation = @"\ElevenFiftyProjects\SD 65\Game_Project\Field.wav";
                sound.Load();
                sound.Play();*/
                 
                Console.Clear();
                Console.WriteLine("What do you want to do?:\n" +
                                "1) Search for clues about Batman \n" +
                                "2) Return to base");
                int selection = 0;
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number.\n" +
                                         "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                switch (selection)
                {
                    case 1:
                        //Search for clues about Batman
                        Console.Clear();
                        searchProgress++;
                        switch (searchProgress)
                        {
                            case 1:
                                Console.WriteLine("You start patrolling the streets. " +
                                    "While perched on a rooftop, you see two of Penguins thugs mugging an elderly lady. " +
                                    "\nWhy are penguins men on this side of town, you think to yourself as you jump into action!");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                GameLogic.NewEnemyEncounter();
                                GameLogic.CombatScene();
                                break;
                            case 2:
                                Console.WriteLine("You interrogate the thugs about what Penguin's scheme is. " +
                                    "\nThey are reluctant to say anything, but you have your ways of making them talk." +
                                    "\nThey swear they don't know anything except that they were sent here by The Penguin to be look outs for the Bat Brats.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("They don't know where The Penguin is, just the bar all his goons hang out in awaiting orders.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("All the sudden you have this sneaking suspicion you're being watched. You ignore it for now. You head to the bar, Flipper.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("On the rooftop of Flipper, you listen to the conversation between the bartender and two other thugs. " +
                                    "\nIt's not a busy night.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("They're talking about Penguin's latest plans to kill Batman and how he will rule the city once the flying rodent is out of the picture. " +
                                    "\nPenguin DOES have Batman.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("All the sudden, the roof gives in and you fall through, landing on a pool table. The thugs are startled, but ready! " +
                                    "\nThey attack!");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                GameLogic.NewEnemyEncounter();
                                GameLogic.CombatScene();
                                break;
                            case 3:
                                Console.WriteLine("One of the thugs is barely holding on, you go to interrogate him when a batarang flies in and knocks him out. " +
                                    "\nYou look up and it's Batwoman, standing on the rooftop.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("She tells you to stop wasting your time and that she knows where The Penguin is keeping Batman. " +
                                    "\nThe IceBerg Lounge.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("She yells at you to keep up and starts across the rooftops toward The Iceberg Lounge. You follow.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Once the two of you are there, " +
                                    "\nyou realize she is who was watching you earlier. " +
                                    "\nYou both make your way through the vents of the lounge until you reach the main hall where you see Penguin giving a generic super villain speech about how tonight is the night that evil wins.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You both burst down through the group of thugs, taking multitudes out with explosives and batarangs on the way down. " +
                                    "\nPenguin is trying to make a run for it with Batman locked in a freezer.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You leap over to separate the two. Penguin pulls his umbrella on you and attacks!");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Batwoman batwoman = new Batwoman();
                                GameLogic.AddHero(batwoman);
                                GameLogic.PenguinEncounter();
                                GameLogic.CombatScene();
                                Console.WriteLine("You pry the freezer door open and Batman falls out. " +
                                    "\nHe doesn't even say thank you.. Because, well, he's Batman.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.WriteLine("YOU SAVED BATMAN!");
                                Console.ReadKey();
                                return;
                                

                                
                        }
                       
                        break;
                    case 2:
                        return;
                       
                    default:
                        Console.Clear();
                        Console.WriteLine("Please make a valid selection\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
           
           
        }
    }
}
