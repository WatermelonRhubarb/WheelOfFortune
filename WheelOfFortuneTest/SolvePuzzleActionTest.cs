using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    /// <summary>
    ///  Unit tests for the SolvePuzzleAction class
    /// </summary>
    [TestClass]
    public class SolvePuzzleActionTest
    {
        // Solve Puzzle Action Tests
        /// <summary>
        /// Tests that a new instance of the SolvePuzzleAction class initializes the property PuzzleGuess with an empty string.
        /// </summary>
        [TestMethod]
        public void SolvePuzzleActionConstructorTest()
        {
            SolvePuzzleAction spa = new SolvePuzzleAction();
            Assert.IsTrue(String.IsNullOrEmpty(spa.PuzzleGuess));
        }

        /// <summary>
        ///  Tests that the Execute() method of the SolvePuzzleAction returns true when the current guess matches the PuzzleAnswer
        /// </summary>
        [TestMethod]
        public void SolvePuzzleActionExecuteCorrectSolutionTest()
        {
            Puzzle currentPuzzle = new Puzzle("WATERMELON");

            SolvePuzzleAction spa = new SolvePuzzleAction();
            spa.PuzzleGuess = "WATERMELON";

            Assert.IsTrue(spa.Execute(currentPuzzle));
        }

        /// <summary>
        /// Tests that the Execute() method of the SolvePuzzleAction returns false when the current guess does not match the PuzzleAnswer
        /// </summary>
        [TestMethod]
        public void SolvePuzzleActionExecuteIncorrectSolutionTest()
        {
            Puzzle currentPuzzle = new Puzzle("WATERMELON");

            SolvePuzzleAction spa = new SolvePuzzleAction();
            spa.PuzzleGuess = "WATERBERRY";

            Assert.IsFalse(spa.Execute(currentPuzzle));
        }
    }

}
