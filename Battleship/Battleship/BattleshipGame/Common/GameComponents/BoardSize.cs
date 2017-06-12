namespace Battleship.BattleshipGame.Common.GameComponents
{
    public struct BoardSize
    {
        public int Rows { get; }
        public int Columns { get; }

        public BoardSize(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }
}
