using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;//Added for easier access to Thread.Sleep();
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is NOT a datatype class, so we will not have any
        //fields, properties, or constructors. It will simply serve
        //as a 'warehouse' of methods related to combat.

        public static void DoAttack(Character attacker, Character defender)
        {
            //Get a random number from 1-100
            Random rand = new Random();
            int roll = rand.Next(1, 101);

            //Nothing is TRULY random in programming, but suspending
            //the code execution briefly may help simulate the
            //'randomness' of the roll.

            //Thread.Sleep() in the System.Threading namespace
            //will provide this brief pause.

            Thread.Sleep(30);

            //If the attacker "hits"
            if(roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //Calculate the damage
                int damageDealt = attacker.CalcDamage();

                //Subtract that damage from the defender's life
                defender.Life -= damageDealt;
                //defender.Life = defender.Life - damageDealt;

                //Print the result in red:
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name, defender.Name, damageDealt);

                Console.ResetColor();
            }
            //else if (roll > (attacker.CalcHitChance() - defender.CalcBlock()))
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);

            //If the monster survives the player's attack,
            //they attack the player.
            if(monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
