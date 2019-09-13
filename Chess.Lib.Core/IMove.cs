using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IMove : IEntity
    {
        (int X, int Y) From { get; set; }
        (int X, int Y) To { get; set; }
        int Turn { get; set; }
        int PieceId { get; set; }
    }
}