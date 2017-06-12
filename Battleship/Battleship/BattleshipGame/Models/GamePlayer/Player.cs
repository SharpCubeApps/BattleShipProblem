using System.Collections.Generic;
using System.Linq;
using Battleship.BattleshipGame.Models.Board;
using Battleship.BattleshipGame.Models.Ships;
using Battleship.Utils;

namespace Battleship.BattleshipGame.Models.GamePlayer
{
    class Player : IPlayer
    {
        private readonly IBattleBoard _gameBoard;
        private readonly List<IShip> _ships;

        public string Name { get; }
        public bool HasLost => _ships.All(ship => ship.IsDestroyed());

        public Player(string name, IBattleBoard gameBoard, List<IShip> ships)
        {
            Name = name;
            _gameBoard = gameBoard;
            _ships = ships;
        }

        /// <summary>
        /// Process shots fired by the opponent
        /// </summary>
        /// <param name="coordinates">Coordiantes in the form "A2", "D3" etc</param>
        /// <returns>returns true if the opponent hits a ship else returns false</returns>
        public bool ProcessShot(string coordinates)
        {
            string shipId;
            int x = InputParser.GetRow(coordinates.Substring(0, 1)) - 1;
            int y = InputParser.GetColumn(coordinates.Substring(1)) - 1;
            if (_gameBoard.ProcessShot(x, y, out shipId))
            {
                return UpdateShipHitCount(shipId, x, y);
            }

            return false;
        }

        /// <summary>
        /// Update hit count of a ship.
        /// </summary>
        /// <param name="shipId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private bool UpdateShipHitCount(string shipId, int x, int y)
        {
            IShip ship = _ships.Find(currentShip => currentShip.Id == shipId);
            if (!ship.CanHitAtPoint(x, y))
            {
                return false;
            }

            ship.UpdateHits(x, y);
            return true;
        }
    }
}
