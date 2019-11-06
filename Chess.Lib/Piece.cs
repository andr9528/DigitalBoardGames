using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;

namespace Chess.Lib.Concrete
{
    public abstract class Piece : IPiece
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public ICollection<IMove> MoveHistory { get; set; }
        public IRuleSet RuleSet { get; set; }
        public int RuleSetId { get; set; }
        public bool Alive { get; set; }
        public string Discriminator { get; private set;}
        public int PlayerBoardId { get; set; }
        public IPlayerBoard PlayerBoard { get; set; }

        public abstract bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}