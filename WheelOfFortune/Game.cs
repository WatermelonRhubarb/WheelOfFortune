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
        private Queue<Player> Players = new Queue<Player>();

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
        /// A List to keep possible puzzles
        /// </summary>
        private List<string> allPuzzles = new List<string>()
        {
            "Hello World",
            "For the night is dark and full of terrors",
            "For the stormcloaks",
            "I wish you good fortune in the wars to come",
            "You know nothing Jon Snow"
        };

        /// <summary>
        /// A method that initialies the Game properties and start the turn
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine("Press any button to start the game!");
            Console.ReadKey(true);
            Console.WriteLine("Please enter your name.");
            string name = Console.ReadLine();
            AddPlayer(name);
            Random random = new();
            int index = random.Next(0, allPuzzles.Count);
            string nextPuzzle = allPuzzles[index];
            Puzzle puzzle = new(nextPuzzle);
            CurrentPuzzle = puzzle;
            StartTurn();
        } 

        /// <summary>
        /// A method that initializes Player and its properties
        /// </summary>
        public void AddPlayer(string name)
        {
            Player newPlayer = new(name);
            Players.Enqueue(newPlayer);
        }


        /// <summary>
        /// A method that starts a Round
        /// </summary>
        public void StartRound()
        {

        }

        /// <summary>
        /// A method that starts a Turn
        /// </summary>
        public void StartTurn()
        {
            string allBlanks = new Regex("\\S").Replace(CurrentPuzzle.PuzzleAnswer, "*");
            Console.WriteLine($"Good luck {Players.Dequeue().Name}! Here's your puzzle: \n");
            Console.WriteLine(allBlanks + "\n");
            ConsoleKeyInfo keyPressed;
            do
            {
                Console.WriteLine("Press 1 to solve. Press 2 to guess a letter. Then press enter.");
                keyPressed = Console.ReadKey(true);
            } while (!keyPressed.Key.Equals(ConsoleKey.D1) && !keyPressed.Key.Equals(ConsoleKey.D2));
            Console.Write("We made it!");

            //CurrentPlayer.PerformAction(keyPressed, CurrentPuzzle);
            // Depending on action, do something
            // (Handle EndGame())
            // Display puzzle and StartTurn()
            // Enqueuing the last player and dequeuing the next player


            //SolvePuzzleAction = 1,
            //GuessLetterAction = 2,
            //SpinTheWheelAction = 3
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

        }

    }
}
