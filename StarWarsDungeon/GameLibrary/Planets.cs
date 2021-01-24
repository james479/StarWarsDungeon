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
            return new Planet("Dathomir", new Villian("Asajj Ventress", villianStory, 70, 20));
        }
    }
}
