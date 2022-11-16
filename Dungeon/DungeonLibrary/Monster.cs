using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS
        private int _minDmg;//We only need this field because it has a business rule.

        //PROPS
        public int MaxDmg { get; set; }
        public int MinDmg { 
            get { return _minDmg; } 
            set
            {
                if(value <= MaxDmg)//If the value is less than or equal to the maximum...
                {
                    _minDmg = value;//Set the value as the minimum damage.
                }
                else//But if it exceeds the maximum...
                {
                    _minDmg = MaxDmg;//Set the value at the maximum.
                }
            }
        }
        public string Description { get; set; }

        //CTOR
        public Monster()
        {

        }
        //Remember: We need ALL of the properties of this Class as parameters, including this inherited from Character.
        //We then use " : base() " and pass in the parameters IN THE SAME ORDER as the FQCTOR on Character.
        public Monster(string name, string description, int hitChance, int block, int life, int maxLife, int minDmg, int maxDmg) : base (name, hitChance, block, maxLife, life)
        {
            //The only assignments we need in the Constructor are those exclusive to Monster.
            //i.e. They are already covered by the base Constructor.
            Description = description;
            MaxDmg = maxDmg;
            MinDmg = minDmg;
        }

        //METHODS
        public override string ToString()
        {
            return base.ToString() + $"\nDamage: {MinDmg} - {MaxDmg}" +
                $"\nDescription: {Description}";//Add the unique properties to the ToString();
        }

        public override int CalcDamage()
        {
            Random rand = new Random();//Create an instance of the Random class.
            int damage = rand.Next(
                    MinDmg,//The minimum will be the minimum Damage.
                    MaxDmg + 1//The exclusive upper bound will be the maximum Damage plus one.
                );
            return damage;
        }
    }
}
