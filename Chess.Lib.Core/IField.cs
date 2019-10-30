using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IField : IEntity
    {
        ICoordinate Coordinate { get; set; }
        int PieceId { get; set; }
    }
}