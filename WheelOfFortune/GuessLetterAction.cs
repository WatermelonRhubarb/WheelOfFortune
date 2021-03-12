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
        /// A property for the Letter Guess
        /// </summary>
        char LetterGuess { get; set; }


        /// <summary>
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the GuessLetterAction type
        /// This function will include the checking the guessed letter and updating the current puzzle if the guessed letter is correct
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate that the puzzle not solved yet</returns>
        /// </summary>
        public override bool Execute(Puzzle currentPuzzle)
        {
            return false;
      
        }
    }
}
