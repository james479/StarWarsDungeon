using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //class to return side character objects
    class SideCharacters
    {
        public static Character GetHondoOhnaka()
        {
            string story = "I am Hondo Ohnaka the greatest space pirate in the galaxy. I am here to help you on your journey and make a buck while doing it. Come see me if you need" +
                "weapons upgrades, life or armour. It will cost you credits of course because I don't do business for free.";

            return new Character("Hondo Ohnaka", story);
        }

        public static Character GetBoKatan(HeroType hero)
        {
            string story = $"I am Bo-Katan the former leader of Mandalore and leader of the Night Owls and former lieutenant of Death Watch. " +
                $"Come see me if you need any supplies. It will cost you because I need to fund my attempt to free Mandalore for the third time. " +
                $"{(hero == HeroType.MANDALORIAN ? "If you defeat Darth Maul and liberate Mandalore I have a special weapon to give you." : "")}";

            return new Character("Bo-Katan", story);
        }

        public static Character GetBobaFett()
        {
            string story = "Hey kid I am Boba Fett. I have seen and done everything across the galaxy. Come to me if you need any assistance in your " +
                "journey. It will cost you some credits of course.";

            return new Character("Boba Fett", story);
        }
    }
}
