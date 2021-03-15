using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Planets
    {
        public static Planet GetDuroPlanet()
        {
            string villianStory = "Cad Bane is one of the best and most feared bounty hunters in the galaxy. Do not under estimate his fighting skills";
            return new Planet("Duro", new Villian("Cade Bane", villianStory, 50, 10));
        }

        public static Planet GetDathomirPlanet()
        {
            string villianStory = "Asajj Ventress is a Dathomirian who was a former Jedi and Sith. She is a member of the Nightsisters. Asajj knows" +
                "how to use the force so procedd with caution";
            return new Planet("Dathomir", new Villian("Asajj Ventress", villianStory, 60, 15));
        }

        public static Planet GetRentor()
        {
            string villianStory = "Grand Admiral Thrawn is a master tactician and one of the smaratest leaders from the old remnants of the old" +
                "Empire. He will know every one of your moves. You must think outside the box.";
            return new Planet("Rentor", new Villian("Grand Admiral Thrawn", villianStory, 70, 15));
        }

        public static Planet GetSerenno()
        {
            string villianStory = "Count Dooku is a Sith lord and former Jedi master. He is a cunning warrior who knows how to harness the power" +
                "of the dark side. You must use all you powers in order to defeat him.";
            return new Planet("Serenno", new Villian("Count Dooku", villianStory, 75, 20));
        }

        public static Planet GetMandalore()
        {
            string villianStory = "Darth Maul is the former apprentice to the evil Sith lord Darth Sidious. He fights with a huge rage. Help to " +
                "liberate Mandalore by defeating him.";
            return new Planet("Mandalore", new Villian("Darth Maul", villianStory, 80, 30));
        }

        public static Planet GetMustafar()
        {
            string villianStory = "Darth Vader is one of the most powerful Sith Lords in the history of the galaxy. ";
            return new Planet("Mustafar", new Villian("Darth Vader", villianStory, 90, 35));
        }

        public static Planet GetNaboo()
        {
            string villianStory = $"Darth Sidious is the most powerful Sith Lord in the galaxy. This will be your ultimate challenge " +
                "in your quest to become the most powerful";
            return new Planet("Naboo", new Villian("Darth Sidious", villianStory, 100, 40));
        }
    }
}
