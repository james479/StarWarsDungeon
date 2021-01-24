using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class Hero : Character
    {
        private int _life;

        public int MaxLife { get; set; }   //hero character wiil have max life 
        public int Armour { get; set; }    //hero armour
        public int MaxHitDamage { get; set; }   //max that a hero can inlict damage on enemy
        public int Credits { get; set; }   //represents currency in the star wars universe
        public int Score { get; set; }     //score of the player
        public Weapon EquippedWeapon { get; set; } //represents equipped weapon for hero
        public Queue<Weapon> WeaponUpgrades { get; set; } //list of all weapons available
        public List<Weapon> WeaponInventory { get; set; }  //list of all weapons and upgrades bought

        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }
        }

        //constructor
        public Hero(string name, string story, int life, int maxLife, int armour, int maxHitDamage, int credits, int score, Weapon equippedWeapon, Queue<Weapon> weaponUpgrades) : 
            base(name, story)
        {
            MaxLife = maxLife;
            Life = life;
            Armour = armour;
            MaxHitDamage = maxHitDamage;
            Credits = credits;
            Score = score;
            EquippedWeapon = equippedWeapon;
            //storing equipped weapon in weapon inventory, player will only start with one weapon
            WeaponUpgrades = weaponUpgrades;
            WeaponInventory = new List<Weapon>() { equippedWeapon };
        }

        //hero will be attacker, villian will be defender
        public int Attack(Villian villain)
        {
            Random rand = new Random();
            int damage = rand.Next(MaxHitDamage + 1) * EquippedWeapon.DamageMultiplier;
            villain.Life -= damage;
            Score += damage * 100;  //incresing players score
            return damage;
        }

        public override string ToString()
        {
            return string.Format($"Name: {Name}\n*************\nLife: {Life}Armour: {Armour}\nMax Life: {MaxLife}\nCredits: {Credits}\nScore: {Score}");
        }
    }
}
