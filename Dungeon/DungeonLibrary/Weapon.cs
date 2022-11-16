using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS
        private int _minDamage;

        //PROPS
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 //Minimum damage must be 1 or greater.
                    && 
                    value <= MaxDamage)//Minimum damage cannot be greater than or equal to Max Damage.
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;//Default damage is 1.
                }
            }
        }
        public WeaponType Type { get; set; }

        //CTORS
        public Weapon(int maxDamage, string name, int bonusHitChance, bool isTwoHanded, int minDamage, WeaponType type)//FQCTOR
        {
            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            MinDamage = minDamage;
            Type = type;
        }

        //METHODS
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\n" +
                "Bonus Hit: {3}%\nType: {4}\t\t{5}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                Type,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }
    }
}
