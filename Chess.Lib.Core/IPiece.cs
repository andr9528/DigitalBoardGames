using System.Collections.Generic;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IPiece : IEntity
    {
        ICollection<IMove> MoveHistory { get; set; }
        IRuleSet RuleSet { get; set; }
        int RuleSetId { get; set; }
        bool Alive { get; set; }
        string Discriminator { get; }
        int PlayerBoardId { get; set; }
        IPlayerBoard PlayerBoard { get; set; }
        IField Field { get; set; }
        
        int? FieldId { get; set; }

        bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}