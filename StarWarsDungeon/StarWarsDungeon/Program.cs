using GameLibrary;
using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            //introducting the game and getting the name of the player
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Star Wars Dungeon game!\nThis game is semi modeled on D&D games except with Star Wars " +
                "characters.\nYou have the choice between playing as a Jedi Knight or a Mandalorian warrior as you rome the galaxy.\n" +
                "Choosing a Jedi will yield give you a basic lightsaber with a chance for upgrades as you play the game.\nThe Jedi will start " +
                "with greater health but no armour.\nChoosing a Mandalorian will give you a basic blaster as a weapon\n with a chance to buy " +
                "better blasters throughout the game.\nA Mandorian will start out with not as much health but some armour. May the force be with you.\n");

            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
            

            //start playing game
            bool didPlayerQuit = false;

            while (!didPlayerQuit)
            {
                Console.Write("Enter the name of your character: ");
                string name = Console.ReadLine();

                System.Threading.Thread.Sleep(500);
                Console.WriteLine("\nWould you like to play as a Jedi or Mandalorian?");
                Console.WriteLine("J)edi");
                Console.WriteLine("M)andalorian");

                ConsoleKey userChoice;
                bool valid = false;
                do
                {
                    userChoice = Console.ReadKey(true).Key;
                    if (userChoice == ConsoleKey.J || userChoice == ConsoleKey.M)
                    {
                        valid = true;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Invalid choice! Try again");
                        Console.WriteLine("Would you like to play as a Jedi or Mandalorian?");
                        Console.WriteLine("J)edi");
                        Console.WriteLine("M)andalorian");
                    }

                } while (!valid);

                Console.WriteLine();

                //creating new player object and determing jedi or mandalorian
                HeroType heroType;
                if (userChoice == ConsoleKey.J)
                {
                    heroType = HeroType.JEDI;
                }
                else
                {
                    heroType = HeroType.MANDALORIAN;
                }

                Hero player = heroType == HeroType.JEDI ? HeroCharacters.GetNewJediCharacter(name) : HeroCharacters.GetNewMandalorianCharacter(name);

                didPlayerQuit = PlayGame(player, heroType, 1, name);

                if (!didPlayerQuit)
                {
                    System.Environment.Exit(1);
                }

                //execute phase 2 of game
                didPlayerQuit = PlayGame(player, heroType, 2, name);

                if (!didPlayerQuit)
                {
                    System.Environment.Exit(1);
                }

                //execute phase 3 of the game
                didPlayerQuit = PlayGame(player, heroType, 3, name);

                if (!didPlayerQuit)
                {
                    System.Environment.Exit(1);
                }

                int playAgain = PlayAgain();

                if (playAgain == 1)
                {
                    didPlayerQuit = true;
                }
               
            }
        }

        //method to play phase of a game
        static bool PlayGame(Hero player, HeroType heroType, int phase, string name)
        {
            bool playQuit = false;
            bool defeatedLevel = false;
            
            //getting phase of the game to play

            do
            {
                IGame game;
                if (phase == 1)
                {
                    game = new PhaseOneGame(player, heroType);
                }
                else if(phase == 2)
                {
                    game = new PhaseTwoGame(player, heroType);
                }
                else
                {
                    game = new PhaseThreeGame(player, heroType);
                }
                
                int gameResult;

                gameResult = game.StartGame();

                switch (gameResult)
                {
                    //defeated level
                    case 0:
                        defeatedLevel = true;
                        break;

                    //player died, give optiont to play again
                    case 1:
                        bool validResponse = false;
                        do
                        {
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine("Do you want to play again? Y/N");
                            string input = Console.ReadLine();
                            switch (input)
                            {
                                case "Y":
                                case "y":
                                    System.Threading.Thread.Sleep(500);
                                    Console.WriteLine("Playing again...");
                                    player = heroType == HeroType.JEDI ? HeroCharacters.GetNewJediCharacter(name) : HeroCharacters.GetNewMandalorianCharacter(name);
                                    validResponse = true;
                                    break;
                                case "N":
                                case "n":
                                    playQuit = true;
                                    validResponse = true;
                                    break;
                            }

                        } while (!validResponse);
                        break;
                    case 2:
                        playQuit = true;
                        break;
                    default:
                        break;
                }

            } while (!playQuit && !defeatedLevel);

            if (defeatedLevel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int PlayAgain()
        {
            int response;
            bool isVlaid = false;

            do
            {
                Console.Write("Press 1 to quit or 2 to keep playing :");
                if (Int32.TryParse(Console.ReadLine(), out response))
                {
                    if (response != 1 || response != 2)
                    {
                        Console.WriteLine("Invalid response");
                    }
                    else
                    {
                        isVlaid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid response");
                }

            } while (!isVlaid);

            return response;
        }
    }
}
