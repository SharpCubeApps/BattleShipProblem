namespace Battleship.BattleshipGame.Models.Ships
{
    internal interface IShipsFactory
    {
        Ship CreateShip(ShipData shipData);
    }
}