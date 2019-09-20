using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Move : IMove
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public (int X, int Y) From { get; set; }
        public (int X, int Y) To { get; set; }
        public int Turn { get; set; }
        public int PieceId { get; set; }
    }
}