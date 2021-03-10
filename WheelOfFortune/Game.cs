using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Queue<Player> Players { get; set; }

        /// <summary>
        /// A list of the rounds throughout the game
        /// </summary>
        List<Round> Rounds { get; set; }

        /// <summary>
        /// A reference for the current player
        /// </summary>
        Player CurrentPlayer { get; set; }

        /// <summary>
        /// The value of the current puzzle to be solved
        /// </summary>
        Puzzle CurrentPuzzle { get; set; }


        /// <summary>
        /// A method that initialies the Game properties and start the turn
        /// </summary>
        public void StartGame()
        {
            

        } 

        /// <summary>
        /// A method that initializes Player and its properties
        /// </summary>
        public void AddPlayer()
        {

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
