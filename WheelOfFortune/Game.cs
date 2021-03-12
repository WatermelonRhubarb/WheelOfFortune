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
            AddPlayer();

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
        public void AddPlayer()
        {
            Console.WriteLine("Hey there! Welcome to Wheel of Fortune! Before we begin, what is your first name?");
            string name = Console.ReadLine();

            // ** user validation check
            // originally had it as an if conditon but realized while loop would be better in the event Player repeatedly does not pass in input for name
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Vanna White would like to know your name. Please input your name once more so we can play the game!");
                name = Console.ReadLine();
            }

            Console.WriteLine($"Hiya, {name}!");

            CurrentPlayer = new Player(name);

            // TODO: Use Players queue to hold multiple players
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
