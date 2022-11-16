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

        //EXAMPLE: Default values with an empty ctor
        public Turtle()
        {
            Name = "Michaelangelo";
            Description = "Turtle power!";
            Life = 70;
            MaxLife = 70;
            HitChance = 60;
            Block = 15;
            MinDmg = 20;
            MaxDmg = 30;
            BonusBlock = 20;
            HidePercent = 25;
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

            //Create an integer to store the calculated Block.
            int calculatedBlock = Block;//Defaults to the regular Block.

            //Create an instance of the Random object.
            Random rand = new Random();

            //Call the instance method Next() of the Random object.
            //Store the results in an integer "percent"
            //Pass 101 as a parameter into the Next() method
            //Now we will never get values greater than 100.
            //Our minimum value will be 1.
            //Our maximum value will be 100.
            //So effectively, there is a true 1/100 chance to get
            //any integer between 1 and 100 for "percent"
            int percent = rand.Next(1, 101);

            //If the integer rolled for percent is less than or equal to
            //the HidePercent chance (some number 1-100), then we'll
            //grant the bonus block for hiding in the shell.
            if(percent <= HidePercent)
            {
                //So for the default Turtle, all values of 1-25
                //rolled for "percent" will trigger the additional
                //Block, adding 20 bonus Block.
                calculatedBlock += BonusBlock;
            }

            //Return the calculated Block!
            //For the default turtle, if they didn't roll 1-25, 
            //they'll get the base Block of 15.
            return calculatedBlock;
        }
    }
}
