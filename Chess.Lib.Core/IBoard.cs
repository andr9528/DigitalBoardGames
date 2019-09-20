using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IBoard : IEntity   
    {
        IRuleSet RuleSet { get; set; }
        List<IField> Fields { get; set; }
        List<IPlayer> Players { get; set; }

        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}