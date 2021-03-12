using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    [TestClass]
    public class UnitTest1
    {
        /* Player Unit Tests */

        /// <summary>
        ///  Tests that the PerformAction() method of the Player class creates and sets the correct Action
        /// </summary>
        [TestMethod]
        public void PlayerPerformActionInstantiatesCorrectAction()
        {
            Puzzle currentPuzzle = new Puzzle();

            Player currentPlayer = new Player();
            int playerInput = 1;
            currentPlayer.PerformAction((WheelOfFortune.Action.ActionType) playerInput - 1, currentPuzzle);
            Assert.IsInstanceOfType(currentPlayer.CurrentAction, typeof(SolvePuzzleAction));
            Assert.IsNotInstanceOfType(currentPlayer.CurrentAction, typeof(GuessLetterAction));

            playerInput = 2;
            currentPlayer.PerformAction((WheelOfFortune.Action.ActionType)playerInput - 1, currentPuzzle);
            Assert.IsInstanceOfType(currentPlayer.CurrentAction, typeof(GuessLetterAction));
            Assert.IsNotInstanceOfType(currentPlayer.CurrentAction, typeof(SolvePuzzleAction));
        }

    }
}
