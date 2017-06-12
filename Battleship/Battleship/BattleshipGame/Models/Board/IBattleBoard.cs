using System.Collections.Generic;
using Battleship.BattleshipGame.Models.Ships;

namespace Battleship.BattleshipGame.Models.Board
{
    public interface IBattleBoard
    {
        bool ProcessShot(int x, int y, out string shipId);
        void PlaceShipsOnBoard(IEnumerable<IShip> ships);
    }
}