using Battleship.BattleshipGame.Common.Enums;

namespace Battleship.BattleshipGame.Models.Ships
{
    public struct ShipData
    {
        public ShipTypes ShipType { get; }
        public int Width { get; }
        public int Height { get; }
        public int X { get; }
        public int Y { get; }
        public ShipData(ShipTypes shipType, int width, int height, int playerOneShipX, int playerOneShipY)
        {
            ShipType = shipType;
            Width = width;
            Height = height;
            X = playerOneShipX;
            Y = playerOneShipY;
        }
    }
}
