using System;
using System.Collections.Generic;
using Battleship.BattleshipGame.Common.Enums;
using Battleship.BattleshipGame.Models.Ships;

namespace Battleship.BattleshipGame.Models.Board
{
    public class BattleBoard : IBattleBoard
    {
        private readonly int _width;
        private readonly int _height;

        private BoardPoint[][] _boardPoints;

        /// <summary>
        /// Represents the game board for a player on which ships are placed
        /// </summary>
        /// <param name="width">Width of the game board</param>
        /// <param name="height">Height of the game board</param>
        public BattleBoard(int width, int height)
        {
            _width = width;
            _height = height;

            InitializeBoard();
        }

        /// <summary>
        /// Initialize the board and mark each point as empty
        /// </summary>
        private void InitializeBoard()
        {
            _boardPoints = new BoardPoint[_height][];
            for (int i = 0; i < _width; i++)
            {
                _boardPoints[i] = new BoardPoint[_width];
                for (int j = 0; j < _height; j++)
                {
                    _boardPoints[i][j] = new BoardPoint(BoardPointStatus.Empty, string.Empty);
                }
            }
        }

        /// <summary>
        /// Process a missile fire. When an opponent fires a missile, this method check and returns true if its a hit, else returns false
        /// </summary>
        /// <param name="x">x/row coordinate of the missile fired</param>
        /// <param name="y">x/col coordinate of the missile fired</param>
        /// <param name="shipId">shipId of the ship that was hit</param>
        /// <returns>true if a ship was hit else returns false</returns>
        public bool ProcessShot(int x, int y, out string shipId)
        {
            if (_boardPoints[x][y].Status == BoardPointStatus.OccupiedByShip)
            {
                _boardPoints[x][y].Status = BoardPointStatus.OccupiedByShip;
                shipId = _boardPoints[x][y].ShipId;
                return true;
            }

            shipId = string.Empty;
            return false;
        }

        /// <summary>
        /// Place all ships of the user on game board
        /// </summary>
        /// <param name="ships"></param>
        public void PlaceShipsOnBoard(IEnumerable<IShip> ships)
        {
            foreach (IShip ship in ships)
            {
                PlaceShip(ship);
            }
        }

        /// <summary>
        /// Place ship on the board
        /// </summary>
        /// <param name="ship"></param>
        private void PlaceShip(IShip ship)
        {
            if (ship.X + ship.Width > _width || ship.Y + ship.Height > _height)
            {
                throw new Exception("Ship is out of bounds of the board");
            }

            for (int i = ship.X; i < ship.X + ship.Width; i++)
            {
                for (int j = ship.Y; j < ship.Y + ship.Height; j++)
                {
                    _boardPoints[j][i] = new BoardPoint(BoardPointStatus.OccupiedByShip, ship.Id);
                }
            }
        }
    }
}
