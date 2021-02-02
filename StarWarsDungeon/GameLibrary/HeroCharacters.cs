using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //this class returns all hero character objects
    public class HeroCharacters
    {
        //static method to return new jedi hero object
        public static Hero GetNewJediCharacter(string name)
        {
            //jedi story
            string jediStory = "You are a young Jedi Padawan finding your way through the galaxy. Armed with your lightsaber, " +
            "be prepared to fight the scum and villainy of the galaxy and make new friends along the way.";

            //setting up inital weapon and inventory, game implementation will only one upgrade at a time with ilghtsabers
            Queue<Weapon> weaponList = GameWeaponsList.getJediWeapons();
            Weapon equippedWeapon = weaponList.Dequeue();

            return new Hero(name, jediStory, 100, 100, 0, 15, 0, 0, equippedWeapon, weaponList);
        } 
        
        public static Hero GetNewMandalorianCharacter(string name)
        {
            //mandalorian story
            string mandalorianStory = "You are a young Mandalorian warrior finding your way through the galaxy. Armed with your " +
            "blaster and armour be prepared to fight the scum and galaxy of the universe and make new friends along the way.";

            Queue<Weapon> weaponList = GameWeaponsList.getMandalorianWeapons();
            Weapon equippedWeapn = weaponList.Dequeue();

            return new Hero(name, mandalorianStory, 60, 100, 50, 10, 0, 0, equippedWeapn, weaponList);
        }
    }
}
