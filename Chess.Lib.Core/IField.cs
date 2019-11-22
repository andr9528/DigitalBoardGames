using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IField : IEntity
    {
        ICoordinate Coordinate { get; set; }
        int CoordinateId { get; set; }
        IFieldPiece Piece { get; set; }
        IBoard Board { get; set; }
        int BoardId { get; set; }

        int? PieceId { get; set; }
    }
}