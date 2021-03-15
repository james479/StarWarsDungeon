using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class Weapon
    {
        public string Name { get; set; }
        public double DamageMultiplier { get; set; }
        public int Cost { get; set; }

        //constructor
        public Weapon(string name, double damageMultiplier, int cost)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
            Cost = cost;
        }

        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
