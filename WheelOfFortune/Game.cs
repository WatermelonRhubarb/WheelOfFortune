using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<Round> Rounds { get; set; }

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
            // Dict to hold names of winners and the amount of rounds won
            Dictionary<string, int> hashMap = new Dictionary<string, int>();

            // For each round, we place the winner in the dict. 
            // The TryGetValue method will create the key and make the value 0 if the key doesn't exist
            foreach(Round round in Rounds)
            {
                hashMap.TryGetValue(round.Winner.Name, out int count);
                hashMap[round.Winner.Name] =  count + 1;
            }

            // Get name of player with max rounds won (key)
            string playerWithMostWins = hashMap.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            // Get the max number of wins (value)
            int maxRoundsWon = hashMap.Aggregate((x, y) => x.Value > y.Value ? x : y).Value;

            // Create a list to hold winner/winners
            List<string> list = new List<string>() { playerWithMostWins };

            // Check for a tie
            foreach(KeyValuePair<string, int> winner in hashMap)
            {
                if (winner.Key != playerWithMostWins && winner.Value == maxRoundsWon)
                {
                    list.Add(winner.Key);
                }
            }

            // Pass list to Prompt.GameOverMessage
            Prompt.GameOverMessage(list);
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
