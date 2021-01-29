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
            return new Planet("Duro", new Villian("Cade Bane", villianStory, 50, 15));
        }

        public static Planet GetDathomirPlanet()
        {
            string villianStory = "Asajj Ventress is a Dathomirian who was a former Jedi and Sith. She is a member of the Nightsisters. Asajj knows" +
                "how to use the force so procedd with caution";
            return new Planet("Dathomir", new Villian("Asajj Ventress", villianStory, 60, 20));
        }

        public static Planet GetRentor()
        {
            string villianStory = "Grand Admiral Thrawn is a master tactician and one of the smaratest leaders from the old remnants of the old" +
                "Empire. He will know every one of your moves. You must think outside the box.";
            return new Planet("Rentor", new Villian("Grand Admiral Thrawn", villianStory, 65, 20));
        }

        public static Planet GetSerenno()
        {
            string villianStory = "Count Dooku is a Sith lord and former Jedi master. He is a cunning warrior who knows how to harness the power" +
                "of the dark side. You must use all you powers in order to defeat him.";
            return new Planet("Serenno", new Villian("Count Dooku", villianStory, 70, 25));
        }

        public static Planet GetMandalore()
        {
            string villianStory = "Darth Maul is the former apprentice to the evil Sith lord Darth Sidious. He fights with a huge rage. Help to " +
                "liberate Mandalore by defeating him.";
            return new Planet("Mandalore", new Villian("Darth Maul", villianStory, 75, 25));
        }
    }
}
