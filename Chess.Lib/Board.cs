using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;

namespace Chess.Lib.Concrete
{
    public abstract class Board : IBoard
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public IRuleSet RuleSet { get; set; }
        public List<IField> Fields { get; set; }
        public List<IPlayer> Players { get; set; }
        public abstract bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}