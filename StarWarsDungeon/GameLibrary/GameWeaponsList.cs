using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //class to return all weapon objects in the game
    class GameWeaponsList
    {
        public static Queue<Weapon> getMandalorianWeapons()
        {
            //use a queue since only one upgrade at a time in order of upgrades
            Queue<Weapon> mandalorianWeapons = new Queue<Weapon>();
            mandalorianWeapons.Enqueue(new Weapon("E11 Blaster", 1, 0));
            mandalorianWeapons.Enqueue(new Weapon("DH-17 Blaster", 2, 200));
            mandalorianWeapons.Enqueue(new Weapon("DL-44 Blaster", 3, 300));
            mandalorianWeapons.Enqueue(new Weapon("DDC Defender Blaster", 4, 400));
                  
            return mandalorianWeapons;
        }

        public static Queue<Weapon> getJediWeapons()
        {
            //use a queue since only one upgrade at a time in order of upgrades
            Queue<Weapon> jediWeapons = new Queue<Weapon>();
            jediWeapons.Enqueue(new Weapon("Lightsaber First Upgrade", 2, 200));
            jediWeapons.Enqueue(new Weapon("Lightsaber Second Upgrade", 3, 300));
            jediWeapons.Enqueue(new Weapon("Lightsaber Third Upgrade", 4, 400));
            jediWeapons.Enqueue(new Weapon("Lightsaber Fourth Upgrade", 5, 500));
            jediWeapons.Enqueue(new Weapon("Lightsaber Fifth Upgrade", 6, 600));

            return jediWeapons;
        }
    }
}
