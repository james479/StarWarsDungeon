using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class Planet
    {
        public string Name { get; set; }
        public Villian VillianOccupyingPlanet { get; set; }

        public Planet(string name, Villian villianOccupyingPlanet)
        {
            Name = name;
            VillianOccupyingPlanet = villianOccupyingPlanet;
        }
    }

}    
