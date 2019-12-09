using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Coordinate : ICoordinate
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int GameId { get; set; }
        public IGame Game { get; set; }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public Coordinate()
        {
            
        }

        public Coordinate(int x, int y, IGame game)
        {
            X = x;
            Y = y;
            Game = game;
        }
    }
}