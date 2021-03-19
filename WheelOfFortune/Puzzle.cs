using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

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

        private Dictionary<char, List<int>> PuzzleDictionary = new Dictionary<char, List<int>>();

        private char[] SplitPuzzle;

        /// <summary>
        /// Constructor initializing Puzzle instance with the input string
        /// </summary>
        public Puzzle()
        {
            PuzzleAnswer = GenerateNewPuzzle();
            SplitPuzzle = new char[PuzzleAnswer.Length];
            
            for (int i = 0; i < PuzzleAnswer.Length; i++)
            {
                if (!Char.IsWhiteSpace(PuzzleAnswer[i]))
                {
                    if (!PuzzleDictionary.ContainsKey(Char.ToLower(PuzzleAnswer[i])))
                    {
                        PuzzleDictionary.Add(Char.ToLower(PuzzleAnswer[i]), new List<int>());
                    }
                    PuzzleDictionary[Char.ToLower(PuzzleAnswer[i])].Add(i);
                    SplitPuzzle[i] = "_"[0];
                }
                else
                {
                    SplitPuzzle[i] = " "[0];
                }
            }

            PuzzleSoFar = String.Join(" ", SplitPuzzle);
        }

        /// <summary>
        /// An array holding previous guesses
        /// </summary>
        public ArrayList guessedLetters { get; set; }
        
        ///<summary></summary>
        private string GenerateNewPuzzle()
        {
            List<string> allPuzzles = new List<string>()
            {
                "Hello World",
                "For the night is dark and full of terrors",
                "For the stormcloaks",
                "I wish you good fortune in the wars to come",
                "You know nothing Jon Snow"
            };
            
            Random rand = new Random();
            return allPuzzles[rand.Next(allPuzzles.Count)];
        }

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
            // Validation to check wether or not this letter was guessed in this puzzle before
            if (!IsLetterGuessedBefore(loweredLetter))
            {
                // if letter wasn't guessed before
                // add the letter to the guessed letters list
                
                guessedLetters.Add(loweredLetter);


                // Compare guess with PuzzleSolution
                isLetterValidInPuzzle = PuzzleAnswer.ToLower().Contains(loweredLetter);
                if (isLetterValidInPuzzle)
                {
                    Console.WriteLine("Correct Guess.");
                }
                else
                {
                    
                    Console.WriteLine("Incorrect Guess...try another letter");
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
            // no letters had been guessed before
            if (guessedLetters == null)
            {
                // initialize the guessed letters list
                guessedLetters = new ArrayList();
            }
            // there is some letters in the guessed letters
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
            foreach (int i in PuzzleDictionary[letter])
            {
                SplitPuzzle[i] = letter;
            }

            PuzzleDictionary[letter].Clear();
            PuzzleSoFar = String.Join(" ", SplitPuzzle);
            return;
        }
    }
}