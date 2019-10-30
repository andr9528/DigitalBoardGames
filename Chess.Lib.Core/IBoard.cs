using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IBoard : IEntity   
    {
        IRuleSet RuleSet { get; set; }
        List<IField> Fields { get; set; }
        List<IPlayerBoard> Players { get; set; }
        int GameId { get; set; }
        IGame Game { get; set; }

        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}