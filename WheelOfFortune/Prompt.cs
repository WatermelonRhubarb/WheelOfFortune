using System;
using System.Collections.Generic;

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
                InvalidInputError error = new InvalidInputError(InvalidInputError.ErrorTypes.EmptyInput);
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
            Console.Write("\nWould you like to add an additional player? (y/n): ");
            string answer = Console.ReadLine();

            while(answer.ToLower() != "y" && answer.ToLower() != "n")
            {
                InvalidInputError error = new InvalidInputError(InvalidInputError.ErrorTypes.InvalidInputYOrN);
                Console.WriteLine($"\n{error.ErrorMessage}");
                Console.Write("Would you like to add an additional player? (y/n): ");
                answer = Console.ReadLine();
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
            int spacerCount = currentPuzzle.PuzzleSoFar.Length + 20;
            string spacer = new string('-', spacerCount);
            string buffer = new string(' ', 9);
            Console.WriteLine("\n" + spacer);
            Console.WriteLine($"|{buffer}{currentPuzzle.PuzzleSoFar}{buffer}|");
            Console.WriteLine(spacer + "\n");

            Console.WriteLine($"Current Player's Turn: {currentPlayer.Name}\n");

            return;
        }

        /// <summary>
        /// A method to ask user for the type of action they will take
        /// <returns>char of '1' or '2' to indicate solving or guessing a letter</returns>
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
            dynamic userInput=null;
            if (action.ActionTypeProperty == Action.ActionType.GuessLetterAction)
            {
                Console.Write("\nStart Guessing: ");
                Console.Write("Enter a letter: ");
                userInput = Console.ReadLine();
                userInput = validateUserGuess(userInput);
                userInput = userInput[0];
            }
            else if(action.ActionTypeProperty == Action.ActionType.SolvePuzzleAction)
            {
                Console.Write("What is your solution to the puzzle?");
                userInput = Console.ReadLine();
                while (userInput.Length == 0)
                {
                    userInput = Prompt.PromptInValidEmptyInputAsPuzzleSolution();
                }
            }
            
            return userInput;
        }
        private static string validateUserGuess(string userInput)
        {
            userInput = userInput.ToLower();
            InvalidInputError error = null;
            bool valid = false;
            do
            {
                if(userInput.Length != 1)
                {
                    if (userInput.Length == 0)//checking if the input is empty
                    {
                        error = new InvalidInputError(InvalidInputError.ErrorTypes.EmptyInput);

                    }
                    else if (userInput.Length > 1)//checking if the input is Multi Letters
                    {
                        error = new InvalidInputError(InvalidInputError.ErrorTypes.ReceivedStringExpectedChar);
                    }
                    Console.Write($"\n{error.ErrorMessage}");
                    valid = false;
                    Console.Write("\nEnter a letter: ");
                    userInput = Console.ReadLine();
                }
                else
                {
                    valid = true;
                }
            }
            while (!valid);
            
            return userInput;
        }


        /// <summary>
        /// A method to prompt to the user that the input is invalid if an empty string is entered as a puzzle solution
        /// </summary>
        public static string PromptInValidEmptyInputAsPuzzleSolution()
        {
            InvalidInputError error = new InvalidInputError(InvalidInputError.ErrorTypes.EmptyInput);
            Console.Write($"\n{error.ErrorMessage}");
            Console.Write("\nPlease enter a valid solution to the puzzle: ");
            string puzzleSolution = Console.ReadLine().ToLower();
            return puzzleSolution;
        }

        /// <summary>
        /// A method to announce the winner or a tie between players
        /// <param name="winners">list of winning players</param>
        /// </summary>
        public static void GameOverMessage(List<string> winners)
        {
        }

    }
}