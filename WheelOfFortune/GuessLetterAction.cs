using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    /// <summary>
    ///  A Class for the Guess Letter Action Type
    /// </summary>
    public class GuessLetterAction : Action
    {
        /// <summary>
        /// GuessLetterAction constructor
        /// </summary>
        public GuessLetterAction()
        {
            ActionTypeProperty = ActionType.GuessLetterAction;
        }
        /// <summary>
        /// A property for the Letter Guess
        /// </summary>
        public char LetterGuess { get; set; }

        private bool validateUserInput(string userInput)
        {
            bool valid = false;
            valid = ValidateUserInputNotEmpty(userInput);
            if (valid)
            {
                valid = ValidateUserInputNotMoreThanOneLetter(userInput);
            }
            return valid;
        }
        private bool ValidateUserInputNotEmpty(string userInput)
        {
            while (userInput.Length == 0)
            {
                Console.WriteLine("Please Guess a letter");
                userInput = Console.ReadLine();
                ValidateUserInputNotEmpty(userInput);
            }
            
            //once the user enter non empty input return valid
            return true;
        }
        private bool ValidateUserInputNotMoreThanOneLetter(string userInput)
        {
            bool valid = false;
            while (userInput.Length > 1)
            {
                Console.WriteLine("No Multi letters guessing allowed.Please guess only one letter..");
                userInput = Console.ReadLine();
                valid = ValidateUserInputNotEmpty(userInput);
                if (valid)
                {
                    valid = ValidateUserInputNotMoreThanOneLetter(userInput);
                }
            }
            return valid;
        }
        /// <summary>
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the GuessLetterAction type
        /// This function will include the checking the guessed letter and updating the current puzzle if the guessed letter is correct
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether or not the letter is valid in puzzle (wasn't guessed before and exists in the puzzle answer)</returns>
        /// </summary>
        public override bool Execute(Puzzle currentPuzzle)
        {
            bool valid = false;
            if(LetterGuess == '\0')
            {
                Console.WriteLine("Start Guessing: Enter a letter:");
                string userInput = Console.ReadLine();
                valid = validateUserInput(userInput);
                //validity (non empty and one letter)
                if (valid)
                {
                    this.LetterGuess = userInput[0];
                }
                
            }
            //check is letter valid in puzzle (wasn't guessed before and exists in the puzzle answer)
            bool letterValidInPuzzle = currentPuzzle.IsLetterValidInPuzzle(this.LetterGuess);
            //check does the guessed letter exist in the Puzzle
            if (letterValidInPuzzle)
            {
                //update the current puzzle
                currentPuzzle.UpdateCurrentPuzzle(this.LetterGuess);
            }

            //bool to indicate whether or not the letter is valid in puzzle(wasn't guessed before and exists in the puzzle answer)
            return letterValidInPuzzle; 
        }
    }
}
