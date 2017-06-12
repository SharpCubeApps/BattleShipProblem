using Battleship.BattleshipGame.Common.GameComponents;
using Battleship.BattleshipGame.Models.Ships;

namespace Battleship.Utils
{
    public interface IInputParser
    {
        void ParseShipData(string input, out ShipData shipDataPlayerOne, out ShipData shipDataPlayerTwo);
        bool TryParseBoardSize(string input, out BoardSize boardSize);
    }
}