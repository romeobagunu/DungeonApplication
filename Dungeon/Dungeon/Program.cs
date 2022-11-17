using DungeonLibrary;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            Console.WriteLine("\n--== The Dragon's Dungeon ==--\n");

            /* BONUS: To use ASCII art:
                1) Open a Console.WriteLine()
                2) Add an @ sign to the beginning of a string.
                3) Paste in the ASCII art.
                   Possible source: https://www.asciiart.eu/
                4) Optionally, set the color before printing the art w/Console.ForegroundColor = ...
                   then reset the color afterwards w/ Console.ResetColor();
             */

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"

                            .     
                          ,*     
                        ,*      
                      ,P       
                    ,8*       
                  ,dP             
                 d8`                
               ,d8`               
              d8P                            
            ,88P                      
           d888*       .d88P            
          d8888b..d888888*          
        ,888888888888888b.           
       ,8*;88888P*****788888888ba.    
      ,8;,8888*        `88888*         
      )8e888*          ,88888be.      
     ,d888`           ,8888888***     
    ,d88P`           ,8888888Pb.     
    888*            ,88888888**   
    `88            ,888888888    
     `P           ,8888888888b
_____________________________________
");
            Console.ResetColor();

            #endregion

            #region Create Player

            //Prompt the user to input their name:
            Console.WriteLine("What is your name?");

            //Store the user input in a string.
            string playerName = Console.ReadLine();
            
            /* BONUS: Customizing the weapons.
                1) Construct custom weapon objects.
                2) Prompt user input.
                3) Surround customization in a menu of its own.
                4) Assign EquippedWeapon property based on user input.
             */

            //1) Construct weapon objects
            Weapon sword1 = new Weapon(40, "Broadsword", 5, true, 30, WeaponType.Sword);
            Weapon bow1 = new Weapon(25, "Longbow", 30, true, 20, WeaponType.Bow);
            Weapon axe1 = new Weapon(60, "War Axe", -15, true, 50, WeaponType.Axe);

            //3a) COUNTER
            bool playerIsChoosingWeapon = true;

            Weapon chosenWeapon;//Weapon object to store user choice.

            Player player = new Player(playerName, 70, 5, 100, 100, PlayerRace.Human, sword1);

            do
            {
                //2a) Prompt user input
                Console.WriteLine("\nChoose your weapon:\n" +
                    "(S) Broadsword\n" +
                    "(L) Longbow\n" +
                    "(A) War Axe\n");
                //Input prompt is a key instead of a line.
                //That way the user just has to press the key
                //instead of typing out a line and pressing enter.
                ConsoleKey userKey = Console.ReadKey().Key;
                Console.Clear();//2b)Clear the console after registering input.

                switch (userKey)//Read user input
                {
                    case ConsoleKey.S://Values are the enumerated values of ConsoleKey
                        playerIsChoosingWeapon = false;//3c) UPDATE
                        player.EquippedWeapon = sword1;//4a)Assign to sword object.
                        break;
                    case ConsoleKey.L:
                        playerIsChoosingWeapon = false;//3c) UPDATE
                        player.EquippedWeapon = bow1;//4b)Assign to bow object.
                        break;
                    case ConsoleKey.A:
                        playerIsChoosingWeapon = false;//3c) UPDATE
                        player.EquippedWeapon = axe1;//4c)Assign to axe object.
                        break;
                    default://If they did not press one of the keys we prompted them to, reload loop
                        Console.WriteLine("Input was invalid. Please press (S), (L), or (A).");
                        break;
                }

            } while (playerIsChoosingWeapon);//3b) CONDITION

            /* BONUS: Customizing the player race.
                1) Prompt user input
                2) Surround in a loop
                3) Assign Race property based on choice.
             */

            Console.Clear();//Clear text from weapon customization

            //2a) COUNTER
            bool playerIsChoosingRace = true;
            do
            {
                //1) Prompt user input
                Console.WriteLine("\nChoose a Race:" +
                    "\n(H) Human" +
                    "\n(D) Dwarf" +
                    "\n(E) Elf");

                //Store key input
                ConsoleKey raceChoice = Console.ReadKey().Key;
                Console.Clear();//Clear the input from the console.

                switch(raceChoice)
                {
                    case ConsoleKey.H:
                        player.Race = PlayerRace.Human;//3) Assign based on input
                        playerIsChoosingRace = false;//2c) UPDATE
                        break;
                    case ConsoleKey.D:
                        player.Race = PlayerRace.Dwarf;//3) Assign based on input
                        player.MaxLife = 150;//Custom properties based on race
                        player.Life = 150;//Custom properties based on race
                        playerIsChoosingRace = false;//2c) UPDATE
                        break;
                    case ConsoleKey.E:
                        player.Race = PlayerRace.Elf;//3) Assign based on input
                        player.MaxLife = 70;//Custom properties based on race
                        player.Life = 70;//Custom properties based on race
                        player.Block = 35;//Custom properties based on race
                        playerIsChoosingRace = false;//2c) UPDATE
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please press (H), (D), or (E).");
                        break;
                }

            } while (playerIsChoosingRace);//2b) CONDITION
            #endregion

            //Track the score:
            int score = 0;
            //We will update this score whenever the player defeats a Monster
            //then display the score to the player when they exit the game.

            #region Gameplay Loop

            bool playerIsAlive = true;//COUNTER for the GAMEPLAY LOOP
            bool playerIsFighting = true;//COUNTER for the COMBAT LOOP

            do//START OF GAMEPLAY LOOP
            {
                //Any code at the top of this loop
                //will execute any time the player
                //defeats a monster.

                #region Create Room & Monster

                //Because we are doing the Console.WriteLine() inside
                //the GetRoom() method, we can just call the method here.
                GetRoom();

                //However, an alternative solution is to return a string
                //from GetRoom() and then pass that into the CW like:
                //Console.WriteLine(GetRoom());
                //Again, this would only work if you have string as
                //the return type of GetRoom(). In my case, I return void,
                //and write to the Console inside the method.

                //Create Monster objects:
                Rabbit r1 = new Rabbit();
                Rabbit r2 = new Rabbit("Buneary", "From the Sinnoh Region!", 20, 20, 70, 0, 5, 10, true);
                Vampire v1 = new Vampire();
                Vampire v2 = new Vampire("The Count", "1! Ah, ah ah. 2! Ah, ah, ah. 3!", 25, 25, 60, 1, 10, 15, false);
                Turtle t1 = new Turtle();
                Turtle t2 = new Turtle("Franklin", "He can count by twos and tie his shoes", 10, 10, 50, 10, 5, 10, 50, 80);

                //Add the Monsters to a Collection:
                Monster[] monsters =
                {
                    r1,
                    r2, r2, r2,
                    v1,
                    v2, v2,
                    t1,
                    t2
                };

                //Pick one at random to place in the room.
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                Console.WriteLine("You encountered {0}!", monster.Name);

                #endregion

                #region Menu Loop

                do
                {
                    Console.WriteLine("\nChoose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) View Player Stats\n" +
                        "M) View Monster Stats\n" +
                        "Q) Quit\n");

                    string fightingChoice = Console.ReadLine();

                    Console.Clear();

                    switch(fightingChoice.ToUpper())
                    {
                        case "A":
                            Combat.DoBattle(player, monster);

                            //Check Monster Health
                            if(monster.Life <= 0)
                            {
                                //Use green text to highlight winning combat:

                                //Select a text color by setting the ForegroundColor property
                                //to an enum value of ConsoleColor.
                                Console.ForegroundColor = ConsoleColor.Green;

                                Console.WriteLine("\nYou killed {0}", monster.Name);

                                //Make sure to reset the color of the Console afterwards.
                                Console.ResetColor();

                                //Increment the score by one.
                                score++;

                                //End this COMBAT LOOP
                                playerIsFighting = false;
                            }
                            break;
                        case "R":
                            Console.WriteLine("Running away!");

                            //Give the monster an 'attack of opportunity' when the player attempts to run away:
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);

                            playerIsFighting = false;
                            break;
                        case "P":
                            //Because we have an override of the ToString() method on our Player class,
                            //that information can be printed to the console simply by passing the 
                            //Player object into the Console.WriteLine();
                            Console.WriteLine(player);
                            break;
                        case "M":
                            //TODO: Print Monster stats. (ToString() method)
                            break;
                        case "Q":
                            playerIsFighting = false;
                            playerIsAlive = false;
                            break;
                        default:
                            Console.WriteLine("Input invalid. Please type a letter from the Menu below and press Enter.");
                            break;
                    }

                    #region Check Player Life

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(@"
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼
____________________________________
");
                        Console.ResetColor();
                        Console.WriteLine("Score: {0}", score);
                        playerIsFighting = false;
                        playerIsAlive = false;
                    }

                    //if(score > 15) {
                    //    Console.WriteLine("You win!");
                    //    playerIsFighting = false;
                    //    playerIsAlive = false;
                    //}

                    #endregion

                } while (playerIsFighting && playerIsAlive);
                //Re-execute the COMBAT LOOP while the player is still fighting.
                
                #endregion
            } while (playerIsAlive);
            //Re-execute the GAMEPLAY LOOP while the player is still alive.
            //This will get a new Room and Monster then re-enter the COMBAT LOOP.

            #endregion

            Console.WriteLine("Thanks for playing!");

        }//end Main()

        private static void GetRoom()
        {
            string[] rooms =
            {
                "A large forge squats against the far wall of this room, and coals glow dimly inside. Before the forge stands a wide block of iron with a heavy-looking hammer lying atop it, no doubt for use in pounding out shapes in hot metal. Other forge tools hang in racks nearby, and a barrel of water and bellows rest on the floor nearby.",
                "Rusting spikes line the walls and ceiling of this chamber. The dusty floor shows no sign that the walls move over it, but you can see the skeleton of some humanoid impaled on some wall spikes nearby.",
                "Tapestries decorate the walls of this room. Although they may once have been brilliant in hue, they now hang in graying tatters. Despite the damage of time and neglect, you can perceive once-grand images of wizards' towers, magical beasts, and symbols of spellcasting.",
                "This room is walled and floored with black marble veined with white. The ceiling is similarly marbled, but the thick pillars that hold it up are white. A stain of blood drips down one side of a nearby pillar.",
                "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it. It's as though the room was gripped in two enormous hands and broken like a loaf of bread. Someone has torn a tall stone door from its hinges somewhere else in the dungeon and used it to bridge the 15-foot gap of the chasm between the two sides of the room. Whatever did that must have possessed tremendous strength because the door is huge, and the enormous hinges look bent and mangled.",
                "Neither light nor darkvision can penetrate the gloom in this chamber. An unnatural shade fills it, and the room's farthest reaches are barely visible. Near the room's center, you can just barely perceive a lump about the size of a human lying on the floor.",
                "A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads. They flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
                "A huge stewpot hangs from a thick iron tripod over a crackling fire in the center of this chamber. A hole in the ceiling allows some of the smoke from the fire to escape, but much of it expands across the ceiling and rolls down to fill the room in a dark fog. Other details are difficult to make out, but some creature must be nearby, because something's cooking.",
                "You open the door to the remains of two humans, an elf, and a dwarf lying on the ground in front of you. It seems that they might once have been wearing armor, except for the elf, who remains dressed in a blue robe. Clearly they were defeated and victors stripped them of their valuables.",
                "You feel a sense of foreboding upon peering into this cavernous chamber. At its center lies a low heap of refuse, rubble, and bones atop which sit several huge broken eggshells. Judging by their shattered remains, the eggs were big enough to hold a crouching man, making you wonder how large -- and where -- the mother is.",
                "You open the door to what must be a combat training room. Rough fighting circles are scratched into the surface of the floor. Wooden fighting dummies stand waiting for someone to attack them. A few punching bags hang from the ceiling.",
                "A 30-foot-tall demonic idol dominates this room of black stone. The potbellied statue is made of red stone, and its grinning face holds what looks to be two large rubies in place of eyes. A fire burns merrily in a wide brazier the idol holds in its lap.",
                "A chill crawls up your spine and out over your skin as you look upon this room. The carvings on the wall are magnificent, a symphony in stonework -- but given the themes represented, it might be better described as a requiem. Scenes of death, both violent and peaceful, appear on every wall framed by grinning skeletons and ghoulish forms in ragged cloaks.",
                "A horrendous, overwhelming stench wafts from the room before you. Small cages containing small animals and large insects line the walls. Some of the creatures look sickly and alive but most are clearly dead. Their rotting corpses and the unclean cages no doubt result in the zoo's foul odor. A cat mews weakly from its cage, but the other creatures just silently shrink back into their filthy prisons.",
                "Huge rusted metal blades jut out of cracks in the walls, and rusting spikes project down from the ceiling almost to the floor. This room may have once been trapped heavily, but someone triggered them, apparently without getting killed. The traps were never reset and now seem rusted in place.",
                 "This chamber was clearly smaller at one time, but something knocked down the wall that separated it from an adjacent room. Looking into that space, you see signs of another wall knocked over. It doesn't appear that anyone made an effort to clean up the rubble, but some paths through see more usage than others."
            };
            Random rollRoom = new Random();
            int randIndex = rollRoom.Next(rooms.Length);
            string roomDesc = rooms[randIndex];
            Console.WriteLine(roomDesc);
        }
    }//end class()
}//end namespace