using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    /// <summary>
    /// Unit tests for Player class
    /// </summary>
    [TestClass]
    public class PlayerTest
    {
        /// <summary>
        ///  Tests that the PerformAction() method of the Player class creates and sets the correct Action
        /// </summary>
        [TestMethod]
        public void PlayerPerformActionInstantiatesCorrectAction()
        {
            Puzzle currentPuzzle = new Puzzle("Test Puzzle");

            Player currentPlayer = new Player("Player");
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
