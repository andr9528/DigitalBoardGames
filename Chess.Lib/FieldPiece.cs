using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class FieldPiece : IFieldPiece
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public IField Field { get; set; }
        public int? FieldId { get; set; }
        public IPiece Piece { get; set; }
        public int? PieceId { get; set; }
    }
}