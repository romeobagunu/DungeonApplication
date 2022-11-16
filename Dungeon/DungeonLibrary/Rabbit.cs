﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Change the access modifier from internal to public.
    //Inherit from Monster by adding ": Monster"
    public class Rabbit : Monster
    {
        //Add any unique properties for this Monster.
        public bool IsFluffy { get; set; }

        //Make sure to add that unique property to the inherited properties in the parameters.
        public Rabbit(string name, string description, int life, int maxLife, int hitChance, int block,
            int minDmg, int maxDmg, bool isFluffy)
            : base (name, description, hitChance, block, life, maxLife, minDmg, maxDmg)
            //Use the base constructor to assign the inherited properties.
        {
            IsFluffy = isFluffy;//Assign the unique property.
        }

        public override string ToString()//EXAMPLE: Override the ToString() using the unique property
        {
            return base.ToString() + (IsFluffy ? "\nIt's so fluffy, I'm gonna die!"
                : "\nNot so fluffy...");
        }

        public override int CalcBlock()//EXAMPLE: Override CalcBlock() using the unique property
        {
            //return base.CalcBlock();
            int calculatedBlock = Block;
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}
