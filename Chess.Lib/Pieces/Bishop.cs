using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete.Pieces
{
    public class Bishop : Piece
    {
        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="board">The board that this piece will be on. Is used to look up its rules</param>
        public Bishop(IBoard board, IGenericRepository handler)
        {
            var boardType = board.GetType();
        }
        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public Bishop()
        {

        }
        public override bool VerifyMove(IMove move, PlayerFacing directionFacing)
        {
            throw new System.NotImplementedException();
        }
    }
}