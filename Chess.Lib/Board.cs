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
        public int RuleSetId { get; set; }
        public ICollection<IField> Fields { get; set; }
        public ICollection<IPlayerBoard> Players { get; set; }
        public string Discriminator { get; private set; }
        public int GameId { get; set; }
        public IGame Game { get; set; }

        public abstract bool VerifyMove(IMove move, PlayerFacing directionFacing);
    }
}