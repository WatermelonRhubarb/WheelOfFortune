using System;

namespace WheelOfFortune
{
    /// <summary>
    /// The main class of the Wheel Of Fortune Application
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point of the Wheel Of Fortune Application that starts the Game
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Wheel Of Fortune");
            
            Game game = new Game();
            game.StartGame();

        }
    }
}
