
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
        /// A method that instantiates a specified Action for the CurrentAction of the Player
        /// <param name="actionType"></param>
        /// <returns>bool to indicate whether the player's action successfully solved the puzzle or not </returns>
        /// </summary>
        public void SetAction(Action.ActionType actionType)
        {
            if (actionType == Action.ActionType.GuessLetterAction)
            {
                CurrentAction = new GuessLetterAction();
            } else if (actionType == Action.ActionType.SolvePuzzleAction)
            {
                CurrentAction = new SolvePuzzleAction();
            }
        }
    }
}