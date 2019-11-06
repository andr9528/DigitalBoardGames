using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;

namespace Chess.Lib.Concrete
{
    public class PlayerBoard : IPlayerBoard
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public PlayerColour Colour { get; set; }
        public ICollection<IPiece> Pieces { get; set; }
        public PlayerFacing Facing { get; set; }
        public IBoard Board { get; set; }
        public IPlayer Player { get; set; }
        public int BoardId { get; set; }
        public int PlayerId { get; set; }
    }
}