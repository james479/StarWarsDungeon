using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //this class will contain static methods to upgrade player life, armour, weapon upgrades
    class PlayerUpgrades
    {
        //add life to player
        public static void AddHealth(Hero player, int healthToAdd)
        {
            player.Life += healthToAdd;
        }

        public static void AddMaxHealth(Hero player, int maxHealthToAdd)
        {
            player.MaxLife += maxHealthToAdd;
        }

        //add armour to player
        public static void AddArmour(Hero player, int armourToAdd)
        {
            player.Armour += armourToAdd;
        }

        public static void AddMaxHitDamage(Hero player, int hitDamage)
        {
            player.MaxHitDamage += hitDamage;
        }

        public static void AddScore(Hero player, int score)
        {
            player.Score += score;
        }

        //upgrade weapon
        public static void UpgradeWeapon(Hero player, Weapon weaponToUpgrade)
        {
            player.EquippedWeapon = weaponToUpgrade;
        }
    }
}
