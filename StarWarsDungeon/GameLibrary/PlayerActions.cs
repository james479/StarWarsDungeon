using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //class of static methods of player actions
    class PlayerActions
    {
        //will return 0 if player wins, 1 if villian wins and 2 if player retreats
        public static int VisitPlanet(Hero player, Villian villian)
        {
            bool playerWins = false;
            bool villianWins = false;
            bool retreat = false;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n" + villian.Story);
            Console.ResetColor();
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + player);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + villian + "\n");
                Console.ResetColor();

                //display options
                DisplayMenuOptions.DisplayFightOptions();
                string userInputOption = Console.ReadLine();
                int userOption;
                if(Int32.TryParse(userInputOption, out userOption))
                {
                    if (userOption == 1 || userOption == 2)
                    {
                        if (userOption == 1)  //attack
                        {
                            //hero attacts villian
                            int villianDamage = player.Attack(villian);
                            if (villian.Life > 0)  //if villian isn't defeated
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"\n{villian.Name} was struck by {player.Name} for {villianDamage} points.");
                                Console.ResetColor();
                            }
                            else  //if villian is defeated
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\nYou have defeated {villian.Name}!");
                                Console.WriteLine("You have been awarded 10 points of health, 10 points of max life and 10 points of armour and 300 credits!\n");
                                Console.ResetColor();
                                PlayerUpgrades.AddHealth(player, 10);
                                PlayerUpgrades.AddMaxHealth(player, 10);
                                PlayerUpgrades.AddCredits(player, 300);
                                PlayerUpgrades.AddArmour(player, 10);

                                PlayerUpgrades.AddScore(player, 500);
                                playerWins = true;
                            }

                            //villian attacts hero if villian hasn't been defeated
                            if(!playerWins)
                            {
                                int heroDamage = villian.Attack(player);
                                if (player.Life > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine($"{player.Name} was struck by {villian.Name} for {heroDamage} points.");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"You have been defeated by {villian.Name}\n");
                                    Console.ResetColor();
                                    villianWins = true;
                                }
                            }
                        }
                        else  //player retreats
                        {
                            retreat = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }

            } while (!playerWins && !villianWins && !retreat);

            //return values based on whats true
            if(playerWins)
            {
                return 0;
            }
            else if (villianWins)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        //method when player visits ally looking for upgrades
        public static void BuyUpgrades(Hero player, HeroType fighterType, Character ally)
        {
            Console.WriteLine($"\n\n{ally.Name}: Hello {player.Name}. Here are some items that will help you on your journey.\n");
            Console.WriteLine(player + "\n");

            bool exit = false;
            do
            {
                DisplayMenuOptions.DisplayItemsToBuy(fighterType);
                string userChoiceInput = Console.ReadLine();
                int userChoice;
                if (Int32.TryParse(userChoiceInput, out userChoice))
                {
                    switch (userChoice)
                    {
                        //user buys health
                        case 1:
                            if (player.Credits >= 100)
                            {
                                PlayerUpgrades.AddHealth(player, 20);
                                player.Credits -= 100;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\n\nYou have purchased 20 points of health\n");
                                Console.ResetColor();
                                Console.WriteLine(player + "\n");
                            }
                            else
                            {
                                Console.WriteLine("You do not have enought credits to purchase this item");
                            }
                            break;

                        //user buy armour
                        case 2:
                            if (player.Credits >= 200)
                            {
                                PlayerUpgrades.AddArmour(player, 20);
                                player.Credits -= 200;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\n\nYou have purchased 20 points of armour\n");
                                Console.ResetColor();
                                Console.WriteLine(player + "\n");
                            }
                            else
                            {
                                Console.WriteLine("You do not have enought credits to purchase this item");
                            }
                            break;

                        //user buys weapons upgrades
                        case 3:
                            bool exitWeaponsUpgrade = false;
                            do
                            {
                                DisplayMenuOptions.DisplayWeaponToUpgrade(player);
                                string userUpgradeOption = Console.ReadLine();
                                int upgradeOption;

                                if (Int32.TryParse(userUpgradeOption, out upgradeOption))
                                {
                                    switch (upgradeOption)
                                    {
                                        //user buys weapon
                                        case 1:
                                            Weapon weaponToBuy = player.WeaponUpgrades.Peek();

                                            if (player.Credits >= weaponToBuy.Cost)
                                            {
                                                player.EquippedWeapon = weaponToBuy;
                                                player.WeaponInventory.Add(player.WeaponUpgrades.Dequeue());
                                                player.Credits -= weaponToBuy.Cost;
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine($"\n\nYou have purchased {player.EquippedWeapon}!\n");
                                                Console.ResetColor();
                                                Console.WriteLine(player + "\n");
                                            }
                                            //not enough credits to buy
                                            else
                                            {
                                                Console.WriteLine("You do not have enough credits to purchase this item.");
                                            }
                                            break;
                                        //view weapon stats
                                        case 2:
                                            Weapon weaponToDisplay = player.WeaponUpgrades.Peek();
                                            DisplayMenuOptions.DisplayWeaponStats(weaponToDisplay);
                                            break;
                                        //user quits
                                        case 3:
                                            exitWeaponsUpgrade = true;
                                            break;
                                        //invalid int
                                        default:
                                            Console.WriteLine("Invalid option");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid option");
                                }
                                
                            } while (!exitWeaponsUpgrade);
                            break;

                        //user quits
                        case 4:
                            exit = true;
                            break;

                        //invalid int
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }

            } while (!exit);

            Console.WriteLine(player + "\n");
        }

    }
}
