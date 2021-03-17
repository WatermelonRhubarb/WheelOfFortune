using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WheelOfFortune
{
    /// <summary>
    /// A class that manages the game and holds all the information about the players,round and puzzle
    /// </summary>
    public class Game
    {

        /// <summary>
        /// A Queue that hold the players playing the game
        /// </summary>
        public Queue<Player> Players = new Queue<Player>();

        /// <summary>
        /// A list of the rounds throughout the game
        /// </summary>
        List<Round> Rounds { get; set; }

        /// <summary>
        /// A reference for the current player
        /// </summary>
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// The value of the current puzzle to be solved
        /// </summary>
        public Puzzle CurrentPuzzle { get; set; }

        /// <summary>
        /// A method that initialies the Game properties and start the turn
        /// </summary>
        public void StartGame()
        {
            Prompt.WelcomeMessage();

            do
            {
                string person = Prompt.CreatePlayer();
                Player newPlayer = new(person);
                Players.Enqueue(newPlayer);
            }
            while (Prompt.AddAdditionalPlayer() == 'y');

            while (Rounds.Count < 3)
            {
                StartRound();
            }

            EndGame();
        }

        /// <summary>
        /// A method that starts a Round
        /// </summary>
        public void StartRound()
        {
            // initialize current puzzle
            CurrentPuzzle = new Puzzle();
            // initialize current round
            CurrentRound = new Round(CurrentPuzzle);
            // so long as CurrentRound.Winner == null, call StartTurn()
            while(CurrentRound.Winner == null)
            {
                StartTurn();
            }
            // add CurrentRound to Round <List> 
            Rounds.Add(CurrentRound);
        }

        /// <summary>
        /// A method that starts a Turn
        /// </summary>
        public void StartTurn()
        {
            Console.WriteLine(CurrentPuzzle.PuzzleSoFar + "\n");

            ConsoleKeyInfo keyPressed;
            int actionKey;

            Console.WriteLine("Press 1 to solve the puzzle or press 2 to guess a letter.");
            keyPressed = Console.ReadKey(true);
            actionKey = (int)Char.GetNumericValue(keyPressed.KeyChar);

            while (actionKey != 1 && actionKey != 2)
            {
                Console.WriteLine("Invalid input! Press 1 to solve the puzzle or press 2 to guess a letter.");
                keyPressed = Console.ReadKey(true);
                actionKey = (int)Char.GetNumericValue(keyPressed.KeyChar);
            }

            bool isPuzzleSolved = CurrentPlayer.PerformAction((Action.ActionType)actionKey - 1, CurrentPuzzle);
            if (isPuzzleSolved)
            {
                EndGame();
            }
            else
            {
                Console.WriteLine(CurrentPuzzle.PuzzleSoFar + "\n");
                StartTurn();
            }
        }

        /// <summary>
        /// A method that ends a Round
        /// </summary>
        public void EndRound()
        {

        }

        /// <summary>
        /// A method that ends the whole Game
        /// </summary>
        public void EndGame()
        {
            Console.WriteLine($"Congratulations, {CurrentPlayer.Name}!");
            Console.WriteLine($"{CurrentPlayer.Name} won the game!");

            return;
        }

    }
}
