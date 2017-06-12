using Battleship.BattleshipGame.Common.Enums;

namespace Battleship.BattleshipGame.Models.Board
{
    /// <summary>
    /// Represents a point on the game board. Each point/coordinate on the board will have on of the BoardPointStatus. A point on which a ship exists will also have a ship id.
    /// </summary>
    internal struct BoardPoint
    {
        public BoardPointStatus Status { get; set; }
        public string ShipId { get; }
        public BoardPoint(BoardPointStatus status, string shipId)
        {
            Status = status;
            ShipId = shipId;
        }
    }
}
