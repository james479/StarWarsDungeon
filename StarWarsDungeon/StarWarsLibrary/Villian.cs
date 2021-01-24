using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class Villian : Character
    {
        public int Life { get; set; }
        public int MaxHitDamage { get; set; }


        public Villian(string name, string story, int life, int maxHitDamage) : base(name, story)
        {
            Life = life;
            MaxHitDamage = maxHitDamage;
        }

        //villian will be attacker and hero will be defender
        public int Attack(Hero hero)
        {
            Random rand = new Random();
            int damage = rand.Next(MaxHitDamage + 1);

            //check to see if hero has armour, if hero has armour, will take away armour score first
            if(hero.Armour > 0)
            {
                //if damage is less than hero armour, will just subtract hero armour based on damage
                if (damage <= hero.Armour)
                {
                    hero.Armour -= damage;
                }
                //if armour is less than damage, will set armour to zero and take off the left over damage from hero's life
                else
                {
                    int leftOverDamage = damage - hero.Armour;
                    hero.Armour = 0;
                    hero.Life -= leftOverDamage;
                }
            }
            else
            {
                hero.Life -= damage;
            }
            return damage;
        }

        public override string ToString()
        {
            return string.Format($"Name: {Name}\n**************\nLife: {Life}");
        }
    }
}
