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

            Console.Write("Enter the name of your character: ");
            string name = Console.ReadLine();

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
                    Console.WriteLine("Invalid choice! Try again");
                    Console.WriteLine("Would you like to play as a Jedi or Mandalorian?");
                    Console.WriteLine("J)edi");
                    Console.WriteLine("M)andalorian");
                }

            } while (!valid);

            Console.WriteLine();

            //creating new player object and determing jedi or mandalorian
            HeroType heroType;
            if(userChoice == ConsoleKey.J)
            {
                heroType = HeroType.JEDI;
            }
            else
            {
                heroType = HeroType.MANDALORIAN;
            }

            Hero player = heroType == HeroType.JEDI ? HeroCharacters.GetNewJediCharacter(name) : HeroCharacters.GetNewMandalorianCharacter(name);

            PhaseOneGame phaseOneGame = new PhaseOneGame(player, heroType);
            int gameResult;

            gameResult = phaseOneGame.StartGame();

        }
    }
}
