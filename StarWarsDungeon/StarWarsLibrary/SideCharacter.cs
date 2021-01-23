using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary 
{
    public class SideCharacter : Character
    {
        public Weapon WeaponToGiveHero { get; set; }

        public SideCharacter(string name, string story, Weapon weaponToGiveHero) : base(name, story)
        {
            WeaponToGiveHero = weaponToGiveHero;
        }
    }
}
