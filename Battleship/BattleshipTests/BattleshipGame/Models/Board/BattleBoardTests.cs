using System.Collections.Generic;
using Battleship.BattleshipGame.Common.Enums;
using Battleship.BattleshipGame.Models.Board;
using Battleship.BattleshipGame.Models.Ships;
using NUnit.Framework;

namespace BattleshipTests.BattleshipGame.Models.Board
{
    [TestFixture()]
    class BattleBoardTests
    {
        [Test]
        public void ProcessShotHitTest()
        {
            BattleBoard battleBoard = new BattleBoard(5, 5);

            IShip ship = new Ship(ShipTypes.Q, 2, 2, 0, 0);
            List<IShip> ships = new List<IShip>
            {
                ship
            };

            battleBoard.PlaceShipsOnBoard(ships);
            string shipId;
            battleBoard.ProcessShot(1, 1, out shipId);
            Assert.AreEqual(shipId, ship.Id);
        }

        [Test]
        public void ProcessShotMissTest()
        {
            BattleBoard battleBoard = new BattleBoard(5, 5);

            IShip ship = new Ship(ShipTypes.Q, 1, 1, 0, 0);
            List<IShip> ships = new List<IShip>
            {
                ship
            };

            battleBoard.PlaceShipsOnBoard(ships);
            string shipId;
            battleBoard.ProcessShot(2, 2, out shipId);
            Assert.AreNotEqual(shipId, ship.Id);
        }
    }
}
