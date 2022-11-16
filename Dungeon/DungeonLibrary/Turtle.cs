using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Turtle : Monster
    {
        //Inherit from Monster ^

        //Add unique properties
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        //Add those unique properties to the parameters of the constructor:
        public Turtle(string name, string description, int life, int maxLife, int hitChance, int block,
            int minDmg, int maxDmg, int bonusBlock, int hidePercent)
            : base(name, description, hitChance, block, life, maxLife, minDmg, maxDmg)
        {
            //Assign the unique properties
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }

        //EXAMPLE: Override the ToString() using the unique property
        public override string ToString()
        {
            return base.ToString() + string.Format("\n{0}% chance it will hide, granting {1} bonus block.",
                HidePercent, BonusBlock);
        }

        //EXAMPLE: Override CalcBlock() using the unique property
        public override int CalcBlock()
        {
            //return base.CalcBlock();

            int calculatedBlock = Block;

            Random rand = new Random();
            int percent = rand.Next(101);

            if(percent <= HidePercent)
            {
                calculatedBlock += BonusBlock;
            }

            return calculatedBlock;
        }
    }
}
