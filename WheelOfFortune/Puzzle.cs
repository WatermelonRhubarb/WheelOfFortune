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
        string PuzzleSoFar { get; set; }

        public Puzzle(string puzzle)
        {
            PuzzleAnswer = puzzle;
        }

        /// <summary>
        /// A method to check whether the passed guessed word <paramref name="phrase"/> matches the puzzle or no
        /// </summary>
        /// <param name="phrase">passed guessed word</param>
        /// <returns>puzzle solved bool</returns>
        public bool IsPuzzleSolved(string phrase)
        {
            bool isPuzzleSolved = false;
            return isPuzzleSolved;
        }

        /// <summary>
        /// A method to check whether a letter <paramref name="letter"/> exists in the Puzzle 
        /// </summary>
        /// <param name="letter">passed guessed letter</param>
        /// <returns>letter in puzzle bool</returns>
        public bool IsLetterInPuzzle(char letter)
        {
            bool isLetterInPuzzle = false;
            return isLetterInPuzzle;
        }


        /// <summary>
        /// A method to update the current puzzle whena right letter <paramref name="letter"/> suggestion is passed
        /// </summary>
        /// <param name="letter">existing passed letter</param>
        public void UpdateCurrentPuzzle(char letter)
        {

        }
    }
}