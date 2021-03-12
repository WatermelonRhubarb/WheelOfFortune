using System.Text;

using System;
using System.Collections;

namespace WheelOfFortune
{
    /// <summary>
    /// A class that holds all the information about the Puzzle
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// A property that holds the puzzle answer
        /// </summary>
        public string PuzzleAnswer { get; set; }

        /// <summary>
        /// A property that holds the current puzzle solution so far
        /// </summary>
        public string PuzzleSoFar { get; set; }

        public Puzzle(string puzzle)
        {
            PuzzleAnswer = puzzle;
            PuzzleSoFar = "";
            //string punctuation = " .?!,'";
            foreach (char character in PuzzleAnswer)
            {
                //if (punctuation.Contains(character))
                if (character == ' ')
                {
                    PuzzleSoFar += character;
                } else
                {
                    PuzzleSoFar += '*';
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ArrayList guessedLetters { get; set; }
        /// <summary>
        /// A method to check whether the passed guessed word <paramref name="phrase"/> matches the puzzle or no
        /// </summary>
        /// <param name="phrase">passed guessed word</param>
        /// <returns>puzzle solved bool</returns>
        public bool IsPuzzleSolved(string phrase)
        {
            bool isSolved = (phrase.Trim().ToLower() == PuzzleAnswer.ToLower());
            if (!isSolved)
            {
                Console.WriteLine($"{phrase} is incorrect!");
            }
            return isSolved;
        }

        /// <summary>
        /// A method to check whether a letter <paramref name="letter"/> is valid to be added in the Puzzle 
        /// (exists in the puzzle answer and hasn't been guessed before)
        /// </summary>
        /// <param name="letter">passed guessed letter</param>
        /// <returns>letter valid to be added in puzzle bool</returns>
        public bool IsLetterValidInPuzzle(char letter)
        {
            char loweredLetter = letter.ToString().ToLower()[0];
            bool isLetterValidInPuzzle = false;
            //Validation to check wether or not this letter was guessed in this puzzle before
            if (!IsLetterGuessedBefore(loweredLetter))
            {
                //if letter wasn't guessed before
                //add the letter to the guessed letters list
                
                guessedLetters.Add(loweredLetter);


                //Compare guess with PuzzleSolution
                isLetterValidInPuzzle = this.PuzzleAnswer.ToLower().Contains(loweredLetter);
                if (isLetterValidInPuzzle)
                {
                    Console.WriteLine("Correct Guess.");
                }
                else
                {
                    
                    Console.WriteLine("Incorrect Guess..try another letter");
                }
            }
            else
            {
                isLetterValidInPuzzle = false;
                Console.WriteLine("This letter had been guessed for this puzzle before.");
            }
           

            return isLetterValidInPuzzle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public bool IsLetterGuessedBefore(char letter)
        {
            bool isLetterGuessedBefore = false;
            //no letters had been guessed before
            if (guessedLetters == null)
            {
                //initialize the guessed letters list
                guessedLetters = new ArrayList();
            }
            //there is some letters in the guessed letters
            else
            {
                if (guessedLetters.Contains(letter))
                {
                    isLetterGuessedBefore = true;
                }

            }
            return isLetterGuessedBefore;

        }

        /// <summary>
        /// A method to update the current puzzle whena right letter <paramref name="letter"/> suggestion is passed
        /// </summary>
        /// <param name="letter">existing passed letter</param>
        public void UpdatePuzzleSoFar(char letter)
        {
            var updatedPuzzleSoFar = new StringBuilder(); ;
            for (int index = 0; index < PuzzleAnswer.Length; index++)
            {
                char correctLetter = PuzzleAnswer[index];
                if (char.ToLower(letter) == char.ToLower(correctLetter))
                {
                    updatedPuzzleSoFar.Append(correctLetter);
                }
                else
                {
                    updatedPuzzleSoFar.Append(PuzzleSoFar[index]);
                }
            }

            PuzzleSoFar = updatedPuzzleSoFar.ToString();

            return;
        }
    }
}