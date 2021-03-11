using System;


namespace WheelOfFortune
{
    /// <summary>
    /// A Class for the Solve Puzzle Action Type
    /// </summary>
    public class SolvePuzzleAction : Action
    {
        /// <summary>
        /// A property for the Puzzle Guess
        /// </summary>
        string PuzzleGuess { get; set; }


        /// <summary>
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the SolveActionPuzzle type
        /// This function will include checking whether the puzzle is solved or not
        /// if puzzle solved it will invoke the win message ,if not a fail message will be invoked 
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether the puzzle was solved or not yet by that action</returns>
        /// </summary>
        public override bool Execute(Puzzle currentPuzzle)
        {
            Console.WriteLine("What is your solution to the puzzle?");
            string guess = Console.ReadLine();
            while (guess.Length == 0)
            {
                Console.WriteLine("Please enter a valid solution to the puzzle: ");
                guess = Console.ReadLine();
            }
            // return currentPuzzle.IsPuzzleSolved(guess);
            return false;
        }
    }
}
