using System;
using Battleship.BattleshipGame.Common.Consts;
using Battleship.BattleshipGame.Common.Enums;
using Battleship.BattleshipGame.Common.GameComponents;
using Battleship.BattleshipGame.Models.Ships;

namespace Battleship.Utils
{
    public class InputParser : IInputParser
    {
        public bool TryParseBoardSize(string input, out BoardSize boardSize)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] inputs = input.Split(' ');
                if (inputs.Length == 2)
                {
                    int columns = GetColumn(inputs[0]);
                    int rows = GetRow(inputs[1]);
                    boardSize = new BoardSize(columns, rows);
                    return true;
                }
            }

            boardSize = new BoardSize(0, 0);
            return false;
        }

        public void ParseShipData(string input, out ShipData playerOneShipData, out ShipData playerTwoShipData)
        {
            //Sample Input
            //Q 1 1 A1 B2
            //P 2 1 D4 C3
            string[] inputs = input.Split(' ');
            string shipName = inputs[0];
            int width = int.Parse(inputs[1]);
            int height = int.Parse(inputs[2]);
            int playerOneShipX = GetRow(inputs[3].Substring(0, 1)) - 1;
            int playerOneShipY = GetColumn(inputs[3].Substring(1)) - 1;
            ShipTypes shipType = (ShipTypes)Enum.Parse(typeof(ShipTypes), shipName);
            playerOneShipData = new ShipData(shipType, width, height, playerOneShipX, playerOneShipY);
            int playerTwoShipX = GetRow(inputs[4].Substring(0, 1)) - 1;
            int playerTwoShipY = GetColumn(inputs[4].Substring(1)) - 1;
            playerTwoShipData = new ShipData(shipType, width, height, playerTwoShipX, playerTwoShipY);
        }

        public static int GetRow(string input)
        {
            if (char.Parse(input) < char.Parse("A") || char.Parse(input) > char.Parse("Z"))
            {
                throw new Exception("Row is not valid");
            }

            return char.Parse(input) - Constants.CharToIntAdjustment;
        }

        public static int GetColumn(string input)
        {
            return int.Parse(input);
        }
    }
}
