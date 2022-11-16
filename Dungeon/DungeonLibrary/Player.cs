using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character//Inheritance syntax: Child Class : Parent Class
    {
        //FIELDS
        //_life is inherited from Character.

        //PROPS
        //Name, HitChance, Block, Life, and MaxLife are inherited from Character.
        //UNIQUE properties of Player:
        public PlayerRace Race { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //CONSTRUCTOR
        //We need to take in all the properties as parameters,
        //EVEN the ones that were inherited from Character.
        public Player(string name, int hitChance, int block, int life, int maxLife, PlayerRace race, Weapon equippedWeapon) : base (name, hitChance, block, maxLife, life)
        {
            //We can borrow the assignments for the inherited properties by using the : base syntax above.
            //Name = name;
            //HitChance = hitChance;
            //Block = block;
            //MaxLife = maxLife;
            //Life = life;

            //All we need to do is assign the unique properties:
            Race = race;
            EquippedWeapon = equippedWeapon;
        }

        //METHODS
        public override string ToString()
        {
            string raceDescription = "";

            switch (Race)
            {
                case PlayerRace.Human:
                    raceDescription = "A normal dude.";
                    break;
                case PlayerRace.Elf:
                    raceDescription = "A regal, magical being.";
                    break;
                case PlayerRace.Dwarf:
                    raceDescription = "AND MY AXE!";
                    break;
            }

            return base.ToString() + "\nDescription: " + raceDescription + "\nWeapon: " + EquippedWeapon;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(
                EquippedWeapon.MinDamage, 
                EquippedWeapon.MaxDamage + 1
                );

            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
