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
        public int RoundMoney { get; set; }

        /// <summary>
        /// A propertythat holds the Player's Wallet Money
        /// </summary>
        public int WalletMoney { get; set; }

        /// <summary>
        /// A Property of type Action holding the Current Action selected by the Player
        /// </summary>
        public Action CurrentAction { get; set; }

        /// <summary>
        /// A constructor method signature for the Player class
        /// <param name="name"></param>
        /// </summary>
        public Player(string name)
        {
            Name = name;
            RoundMoney = 0;
            WalletMoney = 0;
            CurrentAction = null;
        }

        /// <summary>
        /// A method to perform a specific action  on a passed puzzle (solve the puzzle-guess a letter-spin the wheel)
        /// <param name="actionType"></param>
        /// <param name="currentPuzzle"></param>
        /// <returns>bool to indicate whether the player's action successfully solved the puzzle or not </returns>
        /// </summary>
        public bool PerformAction(Action.ActionType actionType, Puzzle currentPuzzle)
        {
            if (actionType == Action.ActionType.GuessLetterAction)
            {
                CurrentAction = new GuessLetterAction();
            } else if (actionType == Action.ActionType.SolvePuzzleAction)
            {
                CurrentAction = new SolvePuzzleAction();
            }
            //return CurrentAction.Execute(currentPuzzle);
            return false;
        }
    }
}