using Chess.Lib.Core;

namespace Chess.Lib.Concrete
{
    public class Move : IMove
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public ICoordinate From { get; set; }
        public ICoordinate To { get; set; }
        public int CoordinateFromId { get; set; }
        public int CoordinateToId { get; set; }
        public int Turn { get; set; }
        public IPiece Piece { get; set; }
        public int PieceId { get; set; }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public Move()
        {
            
        }

        public Move(IPiece piece, ICoordinate to, int turn)
        {
            Piece = piece;
            To = to;
            From = piece.Field.Field.Coordinate;
            Turn = turn;
            IsInstantiated = true;
        }
    }
}