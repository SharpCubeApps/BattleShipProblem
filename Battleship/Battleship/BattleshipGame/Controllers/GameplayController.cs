using System;
using Battleship.BattleshipGame.Models.GamePlayer;
using Battleship.Services;

namespace Battleship.BattleshipGame.Controllers
{
    /// <summary>
    /// Controls the control flow of the game between two players
    /// </summary>
    class GameplayController
    {
        private readonly IOutputService _outputService;

        public GameplayController(IOutputService outputService)
        {
            _outputService = outputService;
        }

        /// <summary>
        /// Starts the game between the two players
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerOneMoves"></param>
        /// <param name="playerTwo"></param>
        /// <param name="playerTwoMoves"></param>
        internal void StartGameplay(IPlayer playerOne, string[] playerOneMoves, IPlayer playerTwo, string[] playerTwoMoves)
        {
            //Bool to toggle between players turns
            var isPlayerOnesTurn = true;

            //Variables to move through the array of moves for each player
            int ptrPlayer1Moves = 0;
            int ptrPlayer2Moves = 0;

            //While one of the player looses
            while (!(playerOne.HasLost || playerTwo.HasLost))
            {
                if (isPlayerOnesTurn)
                {
                    if (ptrPlayer1Moves < playerOneMoves.Length)
                    {
                        //Player one has a valid move left, check if it can hit a missile.
                        bool isHit = playerTwo.ProcessShot(playerOneMoves[ptrPlayer1Moves]);

                        _outputService.ShowMessage(
                            $"{playerOne.Name} fires a missile with targe {playerOneMoves[ptrPlayer1Moves]} and got a {(isHit ? "hit" : "miss")}");

                        isPlayerOnesTurn = isHit;
                        //Try player one's next move
                        ptrPlayer1Moves++;
                    }
                    else
                    {
                        //Show message if player one has used all the missiles
                        _outputService.ShowMessage($"{playerOne.Name} has no more missiles left to launch");
                        isPlayerOnesTurn = false;
                    }
                }
                else
                {
                    if (ptrPlayer2Moves < playerTwoMoves.Length)
                    {
                        bool isHit = playerOne.ProcessShot(playerTwoMoves[ptrPlayer2Moves]);

                        _outputService.ShowMessage(
                            $"{playerTwo.Name} fires a missile with targe {playerTwoMoves[ptrPlayer2Moves]} and got a {(isHit ? "hit" : "miss")}");

                        isPlayerOnesTurn = !isHit;
                        ptrPlayer2Moves++;
                    }
                    else
                    {
                        _outputService.ShowMessage($"{playerTwo.Name} has no more missiles left to launch");
                        isPlayerOnesTurn = true;
                    }
                }

                //Show message if based on current inupts no player can win the game
                if (ptrPlayer1Moves > playerOneMoves.Length &&
                    ptrPlayer2Moves > playerTwoMoves.Length)
                {
                    _outputService.ShowMessage("None of the players can win based on current inputs");
                    break;
                }
            }

            string playerName = playerOne.HasLost ? playerTwo.Name : playerOne.Name;
            _outputService.ShowMessage($"{playerName} won the battle");
        }
    }
}
