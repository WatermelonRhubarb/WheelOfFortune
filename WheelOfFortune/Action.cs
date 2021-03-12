namespace WheelOfFortune
{
    /// <summary>
    /// An abstract class that defines the basic properties of an action along with the functionality required to perform the action
    /// 
    /// </summary>
    public abstract class Action
    {
        /// <summary>
        /// Enumration for the different action types performed by the player
        /// solving the puzzle,guessing a letter and spin the wheels
        /// </summary>
        public enum ActionType
        {
            SolvePuzzleAction,
            GuessLetterAction,
            SpinTheWheelAction
        }

        /// <summary>
        /// A property that carries the type of the action
        /// </summary>
        public ActionType ActionTypeProperty { get; set; }
        
        //puzzle reference object
        // Sprint 2
        // Puzzle CurrentPuzzle { get; set; }


        /// <summary>
        /// An abstract method to be overriden by the inheriting children so each class can include its version of implemnataion according to its type
        /// <param name="currentPuzzle">parameter holds the current puzzle instace</param>
        /// <returns>bool to indicate whether the puzzle was solved by the action executed</returns>
        /// </summary>
        public abstract bool Execute(Puzzle currentPuzzle);
    }
}