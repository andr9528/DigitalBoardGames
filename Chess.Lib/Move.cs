using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Move : IMove
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public ICoordinate From => Piece.Field.Coordinate;
        public ICoordinate To { get; set; }
        public int CoordinateToId { get; set; }
        public int Turn { get; set; }
        public IPiece Piece { get; set; }
        public int PieceId { get; set; }
    }
}