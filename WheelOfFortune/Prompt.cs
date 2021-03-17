
namespace WheelOfFortune
{
    /// <summary>
    /// A class that handles writing to and reading from the console
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        /// A method to welcome the user to the game and waits for a keypress before continuing
        /// </summary>
        public static void WelcomeMessage()
        {

        }

        /// <summary>
        /// A method to get a new player's name
        /// <returns>string name of player</returns>
        /// </summary>
        public static string CreatePlayer()
        {
            return "";
        }

        /// <summary>
        /// A method to ask if another player will be added to game
        /// <returns>char of 'y' or 'n' to indicate if another player will be added</returns>
        /// </summary>
        public static char AddAdditionalPlayer()
        {
            Console.Write("\nWould you like to add an additional player? (y/n): ");
            string answer = Console.ReadLine();

            bool isValidInput = answer.ToLower() == "y" || answer.ToLower() == "n";

            while(!isValidInput)
            {
                Console.Write("Would you like to add an additional player? (y/n): ");
                answer = Console.ReadLine();
                isValidInput = answer.ToLower() == "y" || answer.ToLower() == "n";
            }

            return answer.ToLower()[0];
        }

        /// <summary>
        /// A method to declare who's turn it is and the current state of the puzzle
        /// <param name="currentPlayer">the player who's turn it is</param>
        /// <param name="currentPuzzle">current state of the puzzle</param>
        /// </summary>
        public static void StartTurn(Player currentPlayer, Puzzle currentPuzzle)
        {

        }

        /// <summary>
        /// A method to ask user for the type of action they will take
        /// <returns>char of '1' or '2' to indcate solving or guessing a letter</returns>
        /// </summary>
        public static char GetActionType()
        {
            return ' ';
        }

        /// <summary>
        /// A method to get the phrase or letter guess from the user
        /// <param name="action">the action type of SolvePuzzleAction or GuessLetterAction</param>
        /// <returns>dynamic can return a string or char holding the guess from the user</returns>
        /// </summary>
        public static dynamic PromptAction(Action action)
        {
            return "";
        }

        /// <summary>
        /// A method to announce the winner or a tie between players
        /// <param name="winners">list of winning players</param>
        /// </summary>
        public static void GameOverMessage(Player[] winners)
        {

        }

    }
}