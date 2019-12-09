using Repository.Core;

namespace Chess.Lib.Core
{
    public interface ICoordinate : IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        int GameId { get; set; }
        IGame Game { get; set; }
    }
}