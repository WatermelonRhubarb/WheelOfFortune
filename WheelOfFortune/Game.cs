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
        public List<Round> Rounds { get; set; } = new List<Round>();

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

            // the GetAction method from Prompt class should return 1 or 2 it will indicate whether the user is solving puzzle or guessing a letter 
            // it returns a string however enum values are set to int for index
            // thus changing char to int
            int solveOrGuessActionType = Prompt.GetActionType();

            // Take return value from Prompt.GetActionType method and pass in action type to CurrentPlayer.SetAction
            // This will not return anything, it just sets the action in CurrentAction
            // Action types are enums, 0th property = solvepuzzleaction / 1st property = guessletteraction
            CurrentPlayer.SetAction((Action.ActionType) solveOrGuessActionType - 1);
            

            // CurrentPlayer.CurrentAction argument is set to an action class either guess or solve puzzle so pass action instance into Prompt action function
            // I believe it is a string return value so leaving it as string instead of dynamic for now
            var playerInput = Prompt.PromptAction(CurrentPlayer.CurrentAction);

            // Prompt action will return a valid guess from user (letter or phrase based on what the user selects) so set it to execute function --> playerInput just stores the prompt action call return and pass to execute function
            bool continuePlayerTurn = CurrentPlayer.CurrentAction.Execute(playerInput, CurrentPuzzle);

            // update Round.Winner to determine a winner
            // check the current player's current action 
            // if it is solve puzzle type (from enum return value) execute function returns a boolean (to indicate if they correctly guess or not)
            // if it returns true then you know you have a round winner
            if(continuePlayerTurn == true)
            {
                if(CurrentPlayer.CurrentAction.ActionTypeProperty == Action.ActionType.SolvePuzzleAction)
                {
                    CurrentRound.Winner = CurrentPlayer;
                } 
            } else {
                    // update players and currentplayer if guess is incorrect
                    // when it is false, regardless of the action just take current player and put it back to queue and set to null
                Players.Enqueue(CurrentPlayer);
                CurrentPlayer = null;
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
