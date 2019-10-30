using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IMove : IEntity
    {
        ICoordinate From { get; set; }
        ICoordinate To { get; set; }
        int Turn { get; set; }
        int PieceId { get; set; }
    }
}