using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Field : IField
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PieceId { get; set; }
    }
}