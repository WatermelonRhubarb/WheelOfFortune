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
        /// A reference to round details
        /// </summary>
        public Round CurrentRound { get; set; }

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
            // set new CurrentPlayer if CurrentPlayer is null
            if(CurrentPlayer == null)
            {
                // dequeue from Players list and set to CurrentPlayer aka take next player from queue and set it to current
                CurrentPlayer = Players.Dequeue();
            } 

            // so now that we have a current player, they will start to perform guesses so call on StartTurn method from Prompt class passing in CurrentPlayer and CurrentPuzzle
            Prompt.StartTurn(CurrentPlayer, CurrentPuzzle);

            // the GetAction method from Prompt class should return 1 or 2 from the Enum 
            char solveOrGuessActionType = Prompt.GetActionType();

            // Take return value from Prompt.GetActionType method and pass in action type to CurrentPlayer.SetAction
            // This will not return anything, it just sets the action in CurrentAction 
            CurrentPlayer.SetAction(solveOrGuessActionType);

            // CurrentPlayer.CurrentAction argument is set to an action class either guess or solve puzzle so pass action instance into Prompt action function
            // I believe it is a string return value so leaving it as string instead of dynamic for now
            string playerInput = Prompt.PromptAction(CurrentPlayer.CurrentAction);

            // Prompt action will return a valid guess from user (letter or phrase based on what the user selects) so set it to execute function --> playerInput just stores the prompt action call return and pass to execute function
            CurrentPlayer.CurrentAction.Execute(playerInput, CurrentPuzzle);

            // update Round.Winner to determine a winner
            // check the current player's current action 
            // if it is solve puzzle type (from enum return value) execute function returns a boolean (to indicate if they correctly guess or not)
            // if it returns true then you know you have a round winner
            // HALP not sure if this is right plz feel free to provide feedback
            if(CurrentPlayer.CurrentAction.ActionType == SolvePuzzleAction)
            {
                bool isPuzzleSolved = CurrentPlayer.PerformAction((Action.ActionType)
                if(typeof isPuzzleSolved == true)
                {
                    Round.Winner = CurrentPlayer;
                }
                
            }

            // update players and currentplayer if guess is incorrect
            // when it is false, regardless of the action just take current player and put it back to queue and set to null

            if(typeof isPuzzleSolved == false)
            {
                CurrentPlayer = Players.Enqueue();
                CurrentPlayer = null;

            }
            

            // -----------------------------------------
            // * this is Marlon's old code, didn't want to nix it right away, I am in backup mode like Safi hehe 
            // -----------------------------------------
            /* Console.WriteLine(CurrentPuzzle.PuzzleSoFar + "\n");

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
            */
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
