using System;
using System.Collections.Generic;
using Battleship.BattleshipGame.Common.GameComponents;
using Battleship.BattleshipGame.Models.Board;
using Battleship.BattleshipGame.Models.GamePlayer;
using Battleship.BattleshipGame.Models.Ships;
using Battleship.Services;
using Battleship.Utils;

namespace Battleship.BattleshipGame.Controllers
{
    internal class BattleShipController
    {
        private readonly IInputParser _inputParser;
        private readonly IInputService _inputService;
        private readonly IOutputService _outputService;
        private readonly IShipsFactory _shipsFactory;

        public BattleShipController(IInputParser inputParser, IInputService inputService, IOutputService outputService, IShipsFactory shipsFactory)
        {
            _inputParser = inputParser;
            _inputService = inputService;
            _outputService = outputService;
            _shipsFactory = shipsFactory;
        }

        public void InitializeGame()
        {
            //Create board based on users inputs
            //5 E
            BoardSize boardSize = GetBoardSize(_inputService.GetUserInput());

            //Number of ships
            //2
            int numShips = GetNumberOfShips(_inputService.GetUserInput());
            List<IShip> playerOneShips = new List<IShip>(numShips);
            List<IShip> playerTwoShips = new List<IShip>(numShips);

            for (int i = 0; i < numShips; i++)
            {
                //Create ships for each player
                //Q 1 1 A1 B2
                //P 2 1 D4 C3
                ShipData shipDataPlayerOne, shipDataPlayerTwo;
                _inputParser.ParseShipData(_inputService.GetUserInput(), out shipDataPlayerOne, out shipDataPlayerTwo);

                Ship ship1 = _shipsFactory.CreateShip(shipDataPlayerOne);
                playerOneShips.Add(ship1);

                Ship ship2 = _shipsFactory.CreateShip(shipDataPlayerTwo);
                playerTwoShips.Add(ship2);
            }

            //Create game board for player one
            IBattleBoard playerOneGameBoard = new BattleBoard(boardSize.Columns, boardSize.Rows);
            playerOneGameBoard.PlaceShipsOnBoard(playerOneShips);

            //Create game board for player one
            IBattleBoard playerTwoGameBoard = new BattleBoard(boardSize.Columns, boardSize.Rows);
            playerTwoGameBoard.PlaceShipsOnBoard(playerTwoShips);

            //Take moves of each player as input from user
            string[] playerOneMoves = _inputService.GetUserInput().Split(' ');
            string[] playerTwoMoves = _inputService.GetUserInput().Split(' ' );

            //Create players based on inupts
            IPlayer playerOne = new Player("Player 1", playerOneGameBoard, playerOneShips);
            IPlayer playerTwo = new Player("Player 2", playerTwoGameBoard, playerTwoShips);

            //Start game between the two players
            GameplayController gameplay = new GameplayController(_outputService);
            gameplay.StartGameplay(playerOne, playerOneMoves, playerTwo, playerTwoMoves);

            _inputService.GetUserInput();
        }

        private int GetNumberOfShips(string input)
        {
            int numShips;
            if (int.TryParse(input, out numShips) && numShips != 0)
            {
                return numShips;
            }

            throw new Exception("Number of ships is not valid.");
        }

        private BoardSize GetBoardSize(string input)
        {
            BoardSize boardSize;
            if (_inputParser.TryParseBoardSize(input, out boardSize))
            {
                return boardSize;
            }

            throw new Exception("Specified board size is not valid.");
        }
    }
}
