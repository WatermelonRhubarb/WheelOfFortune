using System;

namespace WheelOfFortune
{
    /// <summary>
    /// A class that holds the Player's Details
    /// </summary>
    public class Player
    {
        /// <summary>
        /// A property holding a player name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A property to keep track of the Round Money for the Player
        /// </summary>
        int RoundMoney { get; set; }

        /// <summary>
        /// A propertythat holds the Player's Wallet Money
        /// </summary>
        int WalletMoney { get; set; }

        /// <summary>
        /// A Property of type Action holding the Current Action selected by the Player
        /// </summary>
        Action CurrentAction { get; set; }

        public Player(string name)
        {
            Name = name;
            RoundMoney = 5;
            WalletMoney = 10;
        }
        public void thing()
        {
            Console.WriteLine(Name, RoundMoney, WalletMoney);
        }
        /// <summary>
        /// A method to perform a specific action  on a passed puzzle (solve the puzzle-guess a letter-spin the wheel)
        /// <param name="actionType"></param>
        /// <param name="currentPuzzle"></param>
        /// <returns>bool to indicate whether the player's action successfully solved the puzzle or not </returns>
        /// </summary>
        //public bool PerformAction(Action.ActionType actionType, Puzzle currentPuzzle)
        //{
        //    return false;
        //}
    }
}