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

        private string validateUserInput(string userInput)
        {
            string validUserInput = "";
            if (userInput.Length != 1)
            {
                Console.WriteLine("Invalid Guess.Please enter a non empty ,non multi letter");
                userInput = Console.ReadLine();
                return userInput;
            }
            else
            {
                return userInput;
            }
            /*string validUserInput = "";
            bool validNotEmpty = false;
            bool validNotMulti = false;
            validNotEmpty = ValidateUserInputNotEmpty(userInput);
            if (validNotEmpty)
            {
                validNotMulti = ValidateUserInputNotMoreThanOneLetter(userInput);
            }
            else//empty letter guessed
            {
                Console.WriteLine("Please Guess a letter");
                userInput = Console.ReadLine();
                validUserInput = validateUserInput(userInput);
            }
            if(validUserInput.Length == 1)
            {
                return validUserInput;
            }
            if (validNotMulti)
            {
                validUserInput = userInput.ToLower();
                return validUserInput;
            }
            else
            {
                Console.WriteLine("No Multi letters guessing allowed.Please guess only one letter:");
                userInput = Console.ReadLine();
                validUserInput = validateUserInput(userInput);
               
            }*/
            return validUserInput;


        }
        private bool ValidateUserInputNotEmpty(string userInput)
        {
            bool validNotEmpty = false;
            if (userInput.Length == 0)
            {
                validNotEmpty = false;
            }
            else
            {
                validNotEmpty = true;
            }
            
           
            return validNotEmpty;
        }
        private bool ValidateUserInputNotMoreThanOneLetter(string userInput)
        {
            bool validNotMulti = false;
           
            if(userInput.Length == 1)
            {
                validNotMulti = true;
            }
            else
            {
                validNotMulti = false;
            }
            
            return validNotMulti;
        }
        /// <summary>
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the GuessLetterAction type
        /// This function will include the checking the guessed letter and updating the current puzzle if the guessed letter is correct
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether or not the letter is valid in puzzle (wasn't guessed before and exists in the puzzle answer)</returns>
        /// </summary>
        public override bool Execute(Puzzle currentPuzzle)
        {
            string validUserInput = "";
          //  bool valid = false;
            if(LetterGuess == '\0')
            {
                Console.WriteLine("Start Guessing: Enter a letter:");
                string userInput = Console.ReadLine();
                validUserInput = validateUserInput(userInput.ToLower());
                //validity (non empty and one letter)
                char loweredLetter = validUserInput[0].ToString().ToLower()[0];
                this.LetterGuess = loweredLetter;

            }
            //check is letter valid in puzzle (wasn't guessed before and exists in the puzzle answer)
            bool letterValidInPuzzle = currentPuzzle.IsLetterValidInPuzzle(this.LetterGuess);
            //check does the guessed letter exist in the Puzzle
            if (letterValidInPuzzle)
            {
                //update the current puzzle
                currentPuzzle.UpdatePuzzleSoFar(this.LetterGuess);
            }

            // return false to inicate the puzzle is not solved yet
            return false; 
        }
    }
}
