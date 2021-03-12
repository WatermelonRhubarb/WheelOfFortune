using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelOfFortune;

namespace WheelOfFortuneTest
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class GuessLetterActionTest
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GuessLetterTest_RightLetterGuess()
        {
            //Arrange
            //Arrange the puzzle 
            Puzzle puzzle = new Puzzle("Hello World");
           // puzzle.PuzzleAnswer = "Hello World";
            puzzle.PuzzleSoFar="H**l* **rl*";
           
            //Arrange the GuessActionLetter
            GuessLetterAction guessLetterAction = new GuessLetterAction();
            guessLetterAction.LetterGuess = 'o';

            //Act
            //executet the action
            guessLetterAction.Execute(puzzle); 
           
            //Assert
            Assert.IsTrue(puzzle.PuzzleSoFar.Contains(guessLetterAction.LetterGuess));
           
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GuessLetterTest_WrongLetterGuess()
        {
            //Arrange
            //Arrange the puzzle 
            Puzzle puzzle = new Puzzle("Hello World");
           // puzzle.PuzzleAnswer = "Hello World";
            puzzle.PuzzleSoFar = "H**l* **rl*";

            //Arrange the GuessActionLetter
            GuessLetterAction guessLetterAction = new GuessLetterAction();
            guessLetterAction.LetterGuess = 's';

            //Act
            //executet the action
            guessLetterAction.Execute(puzzle);          

            //Assert
            Assert.IsFalse(puzzle.PuzzleSoFar.Contains(guessLetterAction.LetterGuess));

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GuessLetterTest_LetterGuessedBefore()
        {
            //Arrange
            //Arrange the puzzle 
            Puzzle puzzle = new Puzzle("Hello World");
           // puzzle.PuzzleAnswer = "Hello World";
            puzzle.PuzzleSoFar = "H**l* **rl*";

            //Arrange the GuessActionLetter
            GuessLetterAction guessLetterAction = new GuessLetterAction();
            //letter guessed once
            guessLetterAction.LetterGuess = 's';
            guessLetterAction.Execute(puzzle);


            //Arrange the GuessActionLetter
            guessLetterAction = new GuessLetterAction();
            //letter guessed second time
            guessLetterAction.LetterGuess = 's';

            //Act
            //execute the action
            bool letterValidInPuzzle = guessLetterAction.Execute(puzzle);

            //Assert
            Assert.IsFalse(letterValidInPuzzle);

        }
    }
}
