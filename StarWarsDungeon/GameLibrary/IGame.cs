using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsLibrary;

namespace GameLibrary
{
    public interface IGame
    {
        Hero Player { get; set; }
        List<Planet> PlanetsInGame { get; set; }
        Character Ally { get; set; }
        HeroType FighterType { get; set; }

        int StartGame();
    }
}
