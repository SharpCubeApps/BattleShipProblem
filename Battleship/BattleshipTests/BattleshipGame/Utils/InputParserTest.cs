using Battleship.BattleshipGame.Common.GameComponents;
using Battleship.Utils;
using NUnit.Framework;

namespace BattleshipTests.BattleshipGame.Utils
{
    [TestFixture]
    class InputParserTest
    {
        [Test]
        public void TestBoardSizeParser()
        {
            IInputParser inputParser = new InputParser();
            BoardSize boardSize;
            string input = "5 E";
            if (inputParser.TryParseBoardSize(input, out boardSize))
            {
                Assert.AreEqual(boardSize.Rows, 5);
                Assert.AreEqual(boardSize.Columns, 5);
            }
        }
    }
}
