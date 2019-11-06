using System.Collections.Generic;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IGame : IEntity
    {
        IBoard Board { get; set; }
        int BoardId { get; set; }
        IRuleSet RuleSet { get; set; }
        int RuleSetId { get; set; }
        int Turn { get; set; }
        bool GameOver { get; set; }


        bool HandleTurn(IPlayer player);
        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}