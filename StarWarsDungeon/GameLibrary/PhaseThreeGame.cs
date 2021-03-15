using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsLibrary;

namespace GameLibrary
{
    public class PhaseThreeGame : IGame
    {
        public Hero Player { get; set; }
        public List<Planet> PlanetsInGame { get; set; }
        public Character Ally { get; set; }
        public HeroType FighterType { get; set; }

        public int GameIteration { get; set; }

        //constructor
        public PhaseThreeGame(Hero player, HeroType fighterType)
        {
            Player = player;
            FighterType = fighterType;

            //getting list of planet in game
            PlanetsInGame = new List<Planet>()
            {
                Planets.GetMustafar(),
                Planets.GetNaboo()
            };

            //getting ally
            Ally = SideCharacters.GetBobaFett();
        }

        public int StartGame()
        {
            bool defeatedOneVillain = false;  //flag to see if one villian has been deafeated
            bool phaseWon = false;     //phase will be won when hero beats two villians on the two planets
            bool quitGame = false;     //game will quit if set to true
            bool playerDead = false;   //will return to the main program and give the player an option to play again

            //introducing the second phase of the game
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Threading.Thread.Sleep(800);
            Console.WriteLine(Ally.Story + "\n");
            Console.ResetColor();

            //starting third phase of the game
            do
            {
                System.Threading.Thread.Sleep(500);
                DisplayMenuOptions.DisplayMainOptions(PlanetsInGame, Ally, true);
                string userInputChoice = Console.ReadLine();

                int userChoice;

                if (Int32.TryParse(userInputChoice, out userChoice))
                {
                    if (userChoice < 1 || userChoice > PlanetsInGame.Count)
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Invalid Choice");
                    }

                    else
                    {
                        //go to planet and fight villain occupying planet
                        int result = PlayerActions.VisitPlanet(Player, PlanetsInGame[userChoice - 1].VillianOccupyingPlanet);
                        //switch based on what happend while visiting planet
                        switch (result)
                        {
                            case 0:
                                //check to seee if hero defeated one villian
                                if (defeatedOneVillain)
                                {
                                    phaseWon = true;
                                }
                                else
                                {
                                    PlanetsInGame.RemoveAt(userChoice - 1);
                                    defeatedOneVillain = true;
                                }
                                break;
                            //if villian defeats hero
                            case 1:
                                playerDead = true;
                                break;
                            //player retreats
                            default:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine($"\nYou have retreated from planet {PlanetsInGame[userChoice - 1].Name}.\n");
                                Console.ResetColor();
                                break;   
                        }
                    }
                }

                else
                {
                    //user selecs buy items
                    if (userInputChoice == "B" || userInputChoice == "b")
                    {
                        PlayerActions.BuyUpgrades(Player, FighterType, Ally);
                    }
                    else if (userInputChoice == "Q" || userInputChoice == "b")
                    {
                        quitGame = true;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Ivalid Choice");
                    }
                }

            } while (!phaseWon && !quitGame && !playerDead);

            if (phaseWon)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Threading.Thread.Sleep(800);
                Console.WriteLine($"\nBoba Fett: Congraulations kid...You are the biggest hero in the galaxy. The {(FighterType == HeroType.JEDI? "Jedi" : "Mandalorians")} should be proud!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Threading.Thread.Sleep(800);
                System.Threading.Thread.Sleep(800);
                Console.WriteLine("Congratulations. You have defeated the most evil and vile scum of the galaxy and have returned peace to everyone!");
                Console.WriteLine("Your life has increased by 50 points");
                Console.WriteLine("Your max life has increased by 20 points");
                Console.WriteLine("Your armour has increased by 20 points");
                Console.WriteLine("Your max hit damage has increased by 20 points");
                Console.WriteLine("You have been awarded 500 credits");
                Console.WriteLine("500 points have been added to your score\n");
                Console.ResetColor();

                PlayerUpgrades.AddMaxHealth(Player, 20);
                PlayerUpgrades.AddHealth(Player, 50);
                PlayerUpgrades.AddArmour(Player, 20);
                PlayerUpgrades.AddMaxHitDamage(Player, 20);
                PlayerUpgrades.AddCredits(Player, 500);
                PlayerUpgrades.AddScore(Player, 500);

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
