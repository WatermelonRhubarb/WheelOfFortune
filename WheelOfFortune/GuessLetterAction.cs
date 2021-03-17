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

        
       
        /// <summary>
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the GuessLetterAction type
        /// This function will include the checking the guessed letter and updating the current puzzle if the guessed letter is correct
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether or not the letter is valid in puzzle (wasn't guessed before and exists in the puzzle answer)</returns>
        /// </summary>
        public override bool Execute(Puzzle currentPuzzle)
        {
 
            if(LetterGuess == '\0')
            {
                //calling the Prompt Handler to prompt the user to guess a letter
                this.LetterGuess = (char)Prompt.PromptAction(this);
               
            }
            // check is letter valid in puzzle (wasn't guessed before and exists in the puzzle answer)
            bool letterValidInPuzzle = currentPuzzle.IsLetterValidInPuzzle(LetterGuess);
            //check does the guessed letter exist in the Puzzle
            if (letterValidInPuzzle)
            {
                // update the current puzzle
                currentPuzzle.UpdatePuzzleSoFar(LetterGuess);
            }

            // return false to indicate the puzzle is not solved yet
            return false; 
        }
    }
}
