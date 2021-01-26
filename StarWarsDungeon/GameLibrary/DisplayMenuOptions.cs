using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //class that contains static methods to display menu items
    public class DisplayMenuOptions
    {
        //method to display main options
        public static void DisplayMainOptions(List<Planet> planets, Character ally, bool meetAlly)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            //this will display options for which planets the player can go to at the phase of the game
            Console.WriteLine("Choose an option:");
            int optionCount = 1;
            foreach (var planet in planets)
            {
                Console.WriteLine($"{optionCount}) Go to planet {planet.Name}");
                optionCount++;
            }
            if (meetAlly)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"B) Buy items from {ally.Name}");
                Console.ResetColor();
            }
            Console.WriteLine("Q) Quit Game");
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }

        //method to display options to buy items
        public static void DisplayItemsToBuy(HeroType fighterType)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n1) 20 points of Health - 100 Credits");
            Console.WriteLine("2) 20 points of Armour - 200 Credits");
            Console.WriteLine($"3) {(fighterType == HeroType.JEDI ? "Lightsaber upgrade" : "New Blaster")}");
            Console.WriteLine("4) Exit");
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }

        public static void DisplayWeaponToUpgrade(Hero player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Weapon weaponToBuy = player.WeaponUpgrades.Peek();
            Console.WriteLine($"\nPurchase the {weaponToBuy} for {weaponToBuy.Cost}.");
            Console.WriteLine("1) Buy item");
            Console.WriteLine("2) View Weapon Stats");
            Console.WriteLine("3) Quit");
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }

        //method to display fight options
        public static void DisplayFightOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1) Attack");
            Console.WriteLine("2) Retreat");
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }

        public static void DisplayWeaponStats(Weapon weapon)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nName: {weapon.Name}\nCost: {weapon.Cost}\nDamage Multiplier: {weapon.DamageMultiplier}\n\n");
            Console.ResetColor();
        }
    }
}
