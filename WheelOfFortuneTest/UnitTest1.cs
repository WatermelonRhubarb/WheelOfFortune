using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    [TestClass]
    public class UnitTest1
    {
        // Solve Puzzle Action Tests
        [TestMethod]
        public void ExecuteCorrectSolutionTest()
        {
            Puzzle currentPuzzle = new Puzzle();
            currentPuzzle.PuzzleAnswer = "WATERMELON";

            SolvePuzzleAction spa = new SolvePuzzleAction();
            spa.PuzzleGuess = "WATERMELON";

            Assert.AreEqual(spa.Execute(currentPuzzle), true);
        }

        [TestMethod]
        public void ExecuteIncorrectSolutionTest()
        {
            Puzzle currentPuzzle = new Puzzle();
            currentPuzzle.PuzzleAnswer = "WATERMELON";

            SolvePuzzleAction spa = new SolvePuzzleAction();
            spa.PuzzleGuess = "WATERBERRY";

            Assert.AreEqual(spa.Execute(currentPuzzle), false);
        }
    }

}
