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
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the GuessLetterAction type
        /// This function will include the checking the guessed letter and updating the current puzzle if the guessed letter is correct
        /// <param name="letterGuess"></param>
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether or not the letter is valid in puzzle (wasn't guessed before and exists in the puzzle answer)</returns>
        /// </summary>
        public override bool Execute(dynamic letterGuess, Puzzle currentPuzzle)
        {
            // check is letter valid in puzzle (wasn't guessed before and exists in the puzzle answer)
            bool letterValidInPuzzle = currentPuzzle.IsLetterValidInPuzzle(letterGuess);
            //check does the guessed letter exist in the Puzzle
            if (letterValidInPuzzle)
            {
                // update the current puzzle
                currentPuzzle.UpdatePuzzleSoFar(letterGuess);
            }

            // return whether guess was correct
            return letterValidInPuzzle; 
        }
    }
}
