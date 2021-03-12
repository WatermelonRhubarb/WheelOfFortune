using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    [TestClass]
    public class PuzzleTest
    {
        [TestMethod]
        public void PuzzleConstructorTest()
        {
            Puzzle currentPuzzle = new Puzzle("Welcome to Microsoft Leap");
            Assert.AreEqual("Welcome to Microsoft Leap", currentPuzzle.PuzzleAnswer);
            Assert.AreEqual("******* ** ********* ****", currentPuzzle.PuzzleSoFar);
        }

        [TestMethod]
        public void UpdatePuzzleSoFarTest_SameCases()
        {
            Puzzle puzzle = new Puzzle("Welcome to Microsoft Leap");

            puzzle.UpdatePuzzleSoFar('W');
            Assert.AreEqual("W****** ** ********* ****", puzzle.PuzzleSoFar);
        }

        [TestMethod]
        public void UpdatePuzzleSoFarTest_DifferentCases()
        {
            Puzzle puzzle = new Puzzle("Welcome to Microsoft Leap");

            puzzle.UpdatePuzzleSoFar('w');
            Assert.AreEqual("W****** ** ********* ****", puzzle.PuzzleSoFar);
        }


        [TestMethod]
        public void UpdatePuzzleSoFarTest_SomeLetterAlreadySolved()
        {
            Puzzle puzzle = new Puzzle("Welcome to Microsoft Leap");

            puzzle.UpdatePuzzleSoFar('t');
            Assert.AreEqual("******* t* ********t ****", puzzle.PuzzleSoFar);

            puzzle.UpdatePuzzleSoFar('w');
            Assert.AreEqual("W****** t* ********t ****", puzzle.PuzzleSoFar);
        }

        [TestMethod]
        public void UpdatePuzzleSoFarTest_LetterInMultiplePlaces()
        {
            Puzzle puzzle = new Puzzle("Welcome to Microsoft Leap");

            puzzle.UpdatePuzzleSoFar('e');
            Assert.AreEqual("*e****e ** ********* *e**", puzzle.PuzzleSoFar);
        }

        [TestMethod]
        public void IsPuzzleSolvedTest()
        {
            Puzzle puzzle = new Puzzle("Welcome to Microsoft Leap");
            Assert.IsFalse(puzzle.IsPuzzleSolved("WatermelonRhubarb"));
            Assert.IsFalse(puzzle.IsPuzzleSolved("Welco me to Microsoft Leap"));
            Assert.IsTrue(puzzle.IsPuzzleSolved("Welcome to Microsoft Leap"));
            Assert.IsTrue(puzzle.IsPuzzleSolved("welCome to mIcROsoFt lEaP"));
            Assert.IsTrue(puzzle.IsPuzzleSolved("        welCome to mIcROsoFt lEaP        "));
        }
    }
}
