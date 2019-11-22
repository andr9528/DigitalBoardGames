using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IFieldPiece : IEntity
    {
        IField Field { get; set; }
        int? FieldId { get; set; }
        IPiece Piece { get; set; }
        int? PieceId { get; set; }
    }
}