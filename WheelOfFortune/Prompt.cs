using System;

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
            Console.WriteLine("\nPress any button to start the game!");
            Console.ReadKey(true);

            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine("\n\tWelcome to Wheel of Fortune!");
            Console.WriteLine("\n------------------------------------------------");
            return;
        }

        /// <summary>
        /// A method to get a new player's name
        /// <returns>string name of player</returns>
        /// </summary>
        public static string CreatePlayer()
        {
            Console.Write("\nWhat should we call you?: ");
            string name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                InvalidInputError error = new InvalidInputError((InvalidInputError.ErrorTypes)0);
                Console.WriteLine($"\n{error.ErrorMessage}");
                Console.Write("Vanna White would like to know your name. \nPlease input your name once more so we can play the game!: ");
                name = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome to the game {name}!");

            return name;
        }

        /// <summary>
        /// A method to ask if another player will be added to game
        /// <returns>char of 'y' or 'n' to indicate if another player will be added</returns>
        /// </summary>
        public static char AddAdditionalPlayer()
        {
            return ' ';
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