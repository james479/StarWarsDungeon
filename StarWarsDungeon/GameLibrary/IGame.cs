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
        List<Villian> Villians { get; set;}
        List<Planet> Planets { get; set; }
        SideCharacter Ally { get; set; }

        void StartGame();
    }
}
