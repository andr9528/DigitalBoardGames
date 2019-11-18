using System;
using System.Collections.Generic;
using Chess.Lib.Concrete.Boards;
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
        public string Discriminator { get; set;}
        public int PlayerBoardId { get; set; }
        public IPlayerBoard PlayerBoard { get; set; }
        public IField Field { get; set; }
        public int FieldId { get; set; }

        public abstract bool VerifyMove(IMove move, PlayerFacing directionFacing);
        protected abstract List<IRule> TwoPlayerRules();

        protected List<IRule> CreateRules(Type boardType)
        {
            switch (boardType.Name)
            {
                case nameof(TwoPlayers):
                    return TwoPlayerRules();
                default:
                    throw new Exception($"No Case exist for the BoardType: {boardType.Name}");
            }
        }

        protected Piece()
        {
            IsInstantiated = true;
        }
    }
}