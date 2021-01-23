using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsLibrary;

namespace GameLibrary
{
    class PhaseOneGame : IGame
    {
        public Hero Player { get; set; }
        public List<Villian> Villians { get; set; }
        public List<Planet> Planets { get; set; }
        public SideCharacter Ally { get; set; }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
