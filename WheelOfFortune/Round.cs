namespace WheelOfFortune
{
    /// <summary>
    /// TODO: A class that holds the round details
    /// </summary>
    public class Round
    {
        //Sprint 2
        /// <summary>
        /// The Round Puzzle
        /// </summary>
        public Puzzle RoundPuzzle { get; set; }
        /// <summary>
        /// The Round Winner
        /// </summary>
        public Player Winner { get; set; }

        /// <summary>
        /// Constructor for the Round class, setting the inputted Puzzle instance as the RoundPuzzle
        /// </summary>
        /// <param name="currentPuzzle"></param>
        public Round(Puzzle currentPuzzle)
        {
            RoundPuzzle = currentPuzzle;
            Winner = null;
        }
    }
}