using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Field : IField
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public ICoordinate Coordinate { get; set; }
        public int PieceId { get; set; }
    }
}