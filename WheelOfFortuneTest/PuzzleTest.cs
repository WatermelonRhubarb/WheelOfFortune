using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    [TestClass]
    public class PuzzleTest
    {
        [TestMethod]
        public void UpdatePuzzleSoFarTest_SameCases()
        {
            Puzzle puzzle = new Puzzle();
            puzzle.PuzzleAnswer = "Welcome to Microsoft Leap";
            puzzle.PuzzleSoFar = "------- -- --------- ----";

            puzzle.UpdatePuzzleSoFar('W');
            Assert.AreEqual("W------ -- --------- ----", puzzle.PuzzleSoFar);
        }

        [TestMethod]
        public void UpdatePuzzleSoFarTest_DifferentCases()
        {
            Puzzle puzzle = new Puzzle();
            puzzle.PuzzleAnswer = "Welcome to Microsoft Leap";
            puzzle.PuzzleSoFar = "------- -- --------- ----";

            puzzle.UpdatePuzzleSoFar('w');
            Assert.AreEqual("W------ -- --------- ----", puzzle.PuzzleSoFar);
        }


        [TestMethod]
        public void UpdatePuzzleSoFarTest_SomeLetterAlreadySolved()
        {
            Puzzle puzzle = new Puzzle();
            puzzle.PuzzleAnswer = "Welcome to Microsoft Leap";
            puzzle.PuzzleSoFar = "------- t- --------t ----";

            puzzle.UpdatePuzzleSoFar('W');
            Assert.AreEqual("W------ t- --------t ----", puzzle.PuzzleSoFar);
        }

        [TestMethod]
        public void UpdatePuzzleSoFarTest_LetterInMultiplePlaces()
        {
            Puzzle puzzle = new Puzzle();
            puzzle.PuzzleAnswer = "Welcome to Microsoft Leap";
            puzzle.PuzzleSoFar = "------- -- --------- ----";

            puzzle.UpdatePuzzleSoFar('e');
            Assert.AreEqual("-e----e -- --------- -e--", puzzle.PuzzleSoFar);
        }
    }
}
