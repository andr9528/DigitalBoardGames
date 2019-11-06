using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Field : IField
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public ICoordinate Coordinate { get; set; }
        public int CoordinateId { get; set; }
        public IPiece Piece { get; set; }
        public int PieceId { get; set; }
        public IBoard Board { get; set; }
        public int BoardId { get; set; }
    }
}