using System;
using System.Collections.Generic;
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
            bool runGame = true;
            while (runGame == true)
            {
                Console.WriteLine("Welcome to Gotham Knights\n");
                Console.WriteLine("1: Play");
                Console.WriteLine("2: Exit\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "Play":
                        //Start Game
                        StartGame();
                        break;
                    case "1":
                        //Start Game
                        StartGame();
                        break;
                    case "Exit":
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
            Console.WriteLine("Batman has been captured. You need to find him.");
            Thread.Sleep(2000);
            Console.Clear();
            var mainPlayer = new Nightwing();
            GameLogic.AddHero(mainPlayer);
            Console.WriteLine("What is your name?");
            mainPlayer.Name = Console.ReadLine();
            while (inGotham == true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Gotham City");
                Console.WriteLine("What do you want to do?:\n" +
                                      "1) Visit Lucious Fox for new gear \n" +
                                      "2) Head to the Bat Cave \n" +
                                      "3) Patrol the streets\n" +
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
                        break;
                    case 2:
                        //BatCave
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
            GameLogic.AddAreaEnemy("Penguin Thug");
            while (inStreets == true)
                {
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
                        PenguinThug thug1 = new PenguinThug(1);
                        Thread.Sleep(100);
                        PenguinThug thug2 = new PenguinThug(1);
                        GameLogic.AddCurrentEnemy(thug1);
                        GameLogic.AddCurrentEnemy(thug2);
                        GameLogic.CombatScene();
                        break;
                    case 2:
                        //
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
           
           
        }
    }
}
