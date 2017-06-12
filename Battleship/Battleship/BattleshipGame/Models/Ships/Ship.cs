using System;
using Battleship.BattleshipGame.Common.Constants;
using Battleship.BattleshipGame.Common.Enums;

namespace Battleship.BattleshipGame.Models.Ships
{
    public class Ship : IShip
    {
        public string Id { get; }
        public ShipTypes ShipType { get; }
        public int Width { get; }
        public int Height { get; }
        public int X { get; }
        public int Y { get; }

        private int[][] _shipMissilePoints;

        public Ship(ShipTypes shipType, int width, int height, int x, int y)
        {
            ShipType = shipType;
            Width = width;
            Height = height;
            X = x;
            Y = y;
            Id = Guid.NewGuid().ToString();
            Initialize();
        }

        private void Initialize()
        {
            _shipMissilePoints = new int[Height][];
            for (int row = 0; row < Height; row++)
            {
                _shipMissilePoints[row] = new int[Width];
                for (int colIndex = 0; colIndex < Width; colIndex++)
                {
                    _shipMissilePoints[row][colIndex] = ShipType == ShipTypes.Q ? Constants.ShipResiliency_TypeQ : Constants.ShipResiliency_TypeP;
                }
            }
        }

        public bool IsDestroyed()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (_shipMissilePoints[row][col] > 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Update the ship coordinates to mark them as hit. This is used to determine if a ship is destroyed completely.
        /// </summary>
        /// <param name="missileX">Board coordinates of the missile</param>
        /// <param name="missileY">Board coordinates of the missible</param>
        public void UpdateHits(int missileX, int missileY)
        {
            _shipMissilePoints[missileX - X][missileY - Y]--;
        }

        public bool CanHitAtPoint(int missileX, int missileY)
        {
            return _shipMissilePoints[missileX - X][missileY - Y] > 0;
        }
    }
}
