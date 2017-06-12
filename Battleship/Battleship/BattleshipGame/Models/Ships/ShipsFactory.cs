namespace Battleship.BattleshipGame.Models.Ships
{
    internal class ShipsFactory : IShipsFactory
    {
        public Ship CreateShip(ShipData shipData)
        {
            return new Ship(shipData.ShipType, shipData.Width, shipData.Height, shipData.X, shipData.Y);
        }
    }
}
