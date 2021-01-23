using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    //this class represents the base class for all characters in the game

    public class Character
    {
        private string _name;

        public string Story { get; set; }   //background story of the character

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value.Length > 0 ? value : "Player1";
            }
        }

        //contructor
        public Character(string name, string story)
        {
            Name = name;
            Story = story;
        }
    }
}
