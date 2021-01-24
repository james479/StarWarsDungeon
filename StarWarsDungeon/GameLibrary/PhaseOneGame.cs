﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsLibrary;

namespace GameLibrary
{
    class PhaseOneGame : IGame
    {
        public Hero Player { get; set; }
        public List<Planet> PlanetsInGame { get; set; }
        public Character Ally { get; set; }
        public HeroType FighterType { get; set; }

        //constructor
        public PhaseOneGame(Hero player, HeroType fighterType)
        {
            Player = player;
            FighterType = fighterType;

            //getting list of planet in game
            PlanetsInGame = new List<Planet>()
            {
                Planets.GetDuroPlanet(),
                Planets.GetDathomirPlanet()
            };

            //getting ally
            Ally = SideCharacters.GetHondoOhnaka();
        }

        public int StartGame()
        {
            Console.WriteLine(Player.Story);

            //flags that will determine direction of the game
            bool defeatedOneVillian = false;    //flag to check if one villian is defeated to determine if hero meets ally
            bool phaseWon = false;     //phase will be won when hero beats two villians on the two planets
            bool quitGame = false;     //game will quit if set to true
            bool playerDead = false;   //will return to the main program and give the player an option to play again
            bool meetAlly = false;     //flag to check if hero meet ally, effects the display menu options

            do
            {
                //checking to see if hero as met ally, will not meet ally until one planet is won
                if (!meetAlly && defeatedOneVillian)
                {
                    Console.WriteLine(Ally.Story);
                    meetAlly = true;
                }

                DisplayMenuOptions.DisplayMainOptions(PlanetsInGame, Ally, meetAlly);
                string userInputChoice = Console.ReadLine();

                int userChoice;
                if (Int32.TryParse(userInputChoice, out userChoice))
                {
                    if (userChoice < 1 || userChoice > PlanetsInGame.Count + 1)
                    {
                        Console.WriteLine("Invalid Choice");
                    }
                    else
                    {
                        //player go to planet and fight villian occupying planet
                        int result = PlayerActions.VisitPlanet(Player, PlanetsInGame[userChoice - 1].VillianOccupyingPlanet);
                        //switch based on what happend while visiting planet
                        switch (result)
                        {
                            //if player defeats villian
                            case 0:
                                //if first villian defeated in the phase of the game
                                if (!defeatedOneVillian)
                                {
                                    defeatedOneVillian = true;
                                    PlanetsInGame.RemoveAt(userChoice - 1);
                                }
                                else
                                {
                                    phaseWon = true;
                                }
                                break;

                            //if villian defeats hero
                            case 1:
                                playerDead = true;
                                break;

                            //player retreats
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    if (userInputChoice == "B" || userInputChoice == "b")
                    {
                        if (meetAlly)
                        {
                            DisplayMenuOptions.DisplayItemsToBuy(FighterType);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
                        }
                    }
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

            if (phaseWon)
            {
                Console.WriteLine("Hondo: It's been fun. Congratulations on your battles won. I must depart you and seek my new operation in the " +
                    "outer rim. Good luck to you!");
                Console.WriteLine("Congratutions! You have conquered this phase of the game. Great work and may the force be with you!");
                Console.WriteLine("Your life has increased by 50 points");
                Console.WriteLine("Your max life has increased by 20 points");
                Console.WriteLine("Your armour has increased by 20 points");
                Console.WriteLine("Your max hit damage has increased by 20 points");
                Console.WriteLine("500 points have been added to your score");

                PlayerUpgrades.AddHealth(Player, 50);
                PlayerUpgrades.AddMaxHealth(Player, 20);
                PlayerUpgrades.AddArmour(Player, 20);
                PlayerUpgrades.AddMaxHitDamage(Player, 20);
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
