using Battleship.BattleshipGame.Common.Attributes;
using Battleship.BattleshipGame.Common.Consts;

namespace Battleship.BattleshipGame.Common.Enums
{
    public enum ShipTypes
    {
        [MissileResilience(Constants.MissileResilienceStrong)]
        Q,
        [MissileResilience(Constants.MissileResilienceWeak)]
        P
    }
}
