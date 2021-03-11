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
            Assert.AreEqual("_______ __ _________ ____", currentPuzzle.PuzzleSoFar);
        }
    }
}
