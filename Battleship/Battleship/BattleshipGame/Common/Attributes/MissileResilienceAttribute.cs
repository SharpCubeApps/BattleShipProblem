using System;

namespace Battleship.BattleshipGame.Common.Attributes
{
    /// <summary>
    /// Attribute to decorate ShipTypes enum with each ships resilience to missiles
    /// </summary>
    public class MissileResilienceAttribute : Attribute
    {
        public int Value { get; }

        public MissileResilienceAttribute(int missiles)
        {
            Value = missiles;
        }
    }
}