using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IField : IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        int PieceId { get; set; }
    }
}