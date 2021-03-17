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
        public string PuzzleGuess { get; set; }

        /// <summary>
        /// SolvePuzzleAction constructor initializes PuzzleGuess with an empty string
        /// </summary>
        public SolvePuzzleAction()
        {
            ActionTypeProperty = ActionType.SolvePuzzleAction;
            PuzzleGuess = "";
        }

        /// <summary>
        /// The Execute Action Implementation overriding the abstract method to provide the specific implemenation for the SolveActionPuzzle type
        /// This function will include checking whether the puzzle is solved or not
        /// if puzzle solved it will invoke the win message ,if not a fail message will be invoked 
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether the puzzle was solved or not yet by that action</returns>
        /// </summary>
        public override bool Execute(Puzzle currentPuzzle)
        {
            //calling the Prompt Handler to prompt the user to solve the puzzle
            PuzzleGuess = Prompt.PromptAction(this);
           
            return currentPuzzle.IsPuzzleSolved(PuzzleGuess);
        }
    }
}
