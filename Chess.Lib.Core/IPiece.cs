using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IPiece : IEntity
    {
        List<IMove> MoveHistory { get; set; }
        IRuleSet RuleSet { get; set; }
        bool Alive { get; set; }


        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}