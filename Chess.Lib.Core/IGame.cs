using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IGame : IEntity
    {
        IBoard Board { get; set; }
        List<IPlayer> Players { get; set; }
        IRuleSet RuleSet { get; set; }
        int Turn { get; set; }


        bool HandleTurn(IPlayer player);
        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}