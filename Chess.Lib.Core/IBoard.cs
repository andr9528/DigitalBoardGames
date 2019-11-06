using System.Collections.Generic;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IBoard : IEntity   
    {
        IRuleSet RuleSet { get; set; }
        int RuleSetId { get; set; }
        ICollection<IField> Fields { get; set; }
        ICollection<IPlayerBoard> Players { get; set; }
        string Discriminator { get; }
        int GameId { get; set; }
        IGame Game { get; set; }

        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}