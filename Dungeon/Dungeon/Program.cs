namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            //Print a welcome.
            #endregion

            #region Create Player
            //TODO: Create an instance of the Player class.
            #endregion

            #region Gameplay Loop

            #region Create Room & Monster

            //TODO: Print a random room description.
            //TODO: Create an instance of a Monster class at random.

            #endregion

            #region Menu Loop

            /*
                TODO: Create menu with options:
                1) Attack
                2) Run Away
                3) Character Info
                4) Monster Info
                5) Exit
             */

            #endregion

            #endregion

        }//end Main()

        private static string GetRoom()
        {
            //Requirements:
            /*
                1. Create a collection of room descriptions.
                2. Randomly print one of those room descriptions to the Console.
             */

            string[] rooms =
            {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }
    }//end class()
}//end namespace