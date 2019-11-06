using Repository.Core;

namespace Chess.Lib.Core
{
    public interface ICoordinate : IEntity
    {
        int X { get; set; }
        int Y { get; set; }
    }
}