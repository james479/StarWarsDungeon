using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsLibrary;

namespace GameLibrary
{
    class PhaseTwoGame : IGame
    {
        public Hero Player { get; set; }
        public List<Planet> PlanetsInGame { get; set; }
        public Character Ally { get; set; }
        public HeroType FighterType { get; set; }

        //constructor
        public PhaseTwoGame(Hero player, HeroType fighterType)
        {
            Player = player;
            FighterType = fighterType;

            //getting list of planets in game
            PlanetsInGame = new List<Planet>()
            {
                Planets.GetRentor(),
                Planets.GetSerenno()
            };

            //getting ally
            Ally = SideCharacters.GetBoKatan(fighterType);
        }

        public int StartGame()
        {

            bool defeatedTwoVillians = false;    //flag to check if first two villians are defeated to determine if hero is allowed to go to last planet in phase
            bool phaseWon = false;     //phase will be won when hero beats two villians on the two planets
            bool quitGame = false;     //game will quit if set to true
            bool playerDead = false;   //will return to the main program and give the player an option to play again

            //introducing the second phase of the game


            //starting second phase of game
            do
            {
                DisplayMenuOptions.DisplayMainOptions(PlanetsInGame, Ally, true);
                string userInputChoice = Console.ReadLine();

                int userChoice;

                if (Int32.TryParse(userInputChoice, out userChoice))
                {
                    if (userChoice < 1 || userChoice > PlanetsInGame.Count)
                    {
                        Console.WriteLine("Invalid Choice");
                    }
                    else
                    {
                        //play go to planet and fight villian occupying planet
                        int result = PlayerActions.VisitPlanet(Player, PlanetsInGame[userChoice - 1].VillianOccupyingPlanet);
                        //switch based on what happend while visiting planet
                        switch (result)
                        {
                            case 0:
                                //check to see if hero defeated last villian in phase
                                if (defeatedTwoVillians)
                                {
                                    phaseWon = true;
                                }
                                else
                                {
                                    PlanetsInGame.RemoveAt(userChoice - 1);
                                    //if two planets are defeated, unlock last planet
                                    if (!PlanetsInGame.Any())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"\nHelp liberate {(FighterType == HeroType.MANDALORIAN ? "your home planet Mandalore" : "the planet Manadlore")} from the clutches of " +
                                            $"Darth Maul.\n");
                                        Console.ResetColor();
                                        PlanetsInGame.Add(Planets.GetMandalore());
                                        defeatedTwoVillians = true;
                                    }
                                }
                                break;

                            //if villian defeats hero
                            case 1:
                                playerDead = true;
                                break;

                            //player retreats
                            default:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\nYou have retreated from planet {PlanetsInGame[userChoice - 1].Name}.\n");
                                Console.ResetColor();
                                break;
                        }
                    }
                }
                else
                {
                    //user selects buy items
                    if (userInputChoice == "B" || userInputChoice == "b")
                    {
                        DisplayMenuOptions.DisplayItemsToBuy(FighterType);
                        PlayerActions.BuyUpgrades(Player, FighterType, Ally);
                    }

                    //user quits game
                    else if (userInputChoice == "Q" || userInputChoice == "q")
                    {
                        quitGame = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                    }

                }
            } while (!phaseWon && !quitGame && !playerDead);

            //if phase won a mandalorian will automatically get the darksaber as a weapon
            if (phaseWon)
            {
                if (FighterType == HeroType.MANDALORIAN)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nBo-Katan: You have liberated our home planet and won the darksaber from Darth Maul. You are now the Mandalore, ruler of our planet. All of the Clans of" +
                        "Mandalore will now pledge their allegiance to you.");
                    Console.ResetColor();
                    Weapon darksaber = GameWeaponsList.getDarksaber();
                    Player.WeaponInventory.Add(darksaber);   //adding darksaber to inventory

                    //giving player an option to equip darksaber
                    bool isValidWeaponChoice = false;
                    do
                    {
                        Console.WriteLine("Do you want to equipped the Darksaber? Y/N");
                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "Y":
                            case "y":
                                Player.EquippedWeapon = darksaber;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\nYou have now equipped the DarkSaber, the most powerful Mandalorian weapon in the galaxy!\n");
                                Console.ResetColor();
                                isValidWeaponChoice = true;
                                break;
                            case "N":
                            case "n":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("The Darksaber will be in your weapons inventory in case you change your mind.");
                                Console.ResetColor();
                                isValidWeaponChoice = true;
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    } while (!isValidWeaponChoice);

                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Congratutions! You have conquered this phase of the game. Great work and may the force be with you!");
                Console.WriteLine("Your life has increased by 70 points");
                Console.WriteLine("Your max life has increased by 30 points");
                Console.WriteLine("Your armour has increased by 50 points");
                Console.WriteLine("Your max hit damage has increased by 30 points");
                Console.WriteLine("You have been awarded 1000 credits");
                Console.WriteLine("1000 points have been added to your score\n");
                Console.ResetColor();

                PlayerUpgrades.AddMaxHealth(Player, 30);
                PlayerUpgrades.AddHealth(Player, 70);
                PlayerUpgrades.AddArmour(Player, 50);
                PlayerUpgrades.AddMaxHitDamage(Player, 30);
                PlayerUpgrades.AddCredits(Player, 1000);
                PlayerUpgrades.AddScore(Player, 1000);

                return 0;
            }

            else if (playerDead)
            {
                return 1;
            }
            else   //player quit game
            {
                return 2;
            }
        }
    }
}
