namespace Battleship.BattleshipGame.Models.GamePlayer
{
    internal interface IPlayer
    {
        string Name { get; }
        bool HasLost { get; }
        bool ProcessShot(string coordinates);
    }
}