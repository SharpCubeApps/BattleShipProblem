using Battleship.BattleshipGame.Common.Enums;

namespace Battleship.BattleshipGame.Board
{
    public interface IBoardPoint
    {
        BoardPointStatus Status { get; set; }
        string ShipId { get; }
    }
}