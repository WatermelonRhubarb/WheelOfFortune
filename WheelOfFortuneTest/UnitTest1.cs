using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    [TestClass]
    public class UnitTest1
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
    }
}
