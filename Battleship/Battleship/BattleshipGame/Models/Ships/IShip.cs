using Battleship.BattleshipGame.Common.Enums;

namespace Battleship.BattleshipGame.Models.Ships
{
    public interface IShip
    {
        string Id { get; }
        ShipTypes ShipType { get; }
        int Width { get; }
        int Height { get; }
        int X { get; }
        int Y { get; }
        bool IsDestroyed();
        void UpdateHits(int missileX, int missileY);
        bool CanHitAtPoint(int missileX, int missileY);
    }
}