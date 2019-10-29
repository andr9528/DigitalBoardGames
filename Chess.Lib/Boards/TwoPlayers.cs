using Chess.Lib.Core;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Concrete.Boards
{
    public class TwoPlayers : Board
    {
        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="player1Name"> The Name of player one</param>
        /// <param name="player2Name"> The Name of player two</param>
        public TwoPlayers(IGenericRepository handler, params Player[] players)
        {
            
        }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public TwoPlayers()
        {
            
        }

        public override bool VerifyMove(IMove move, PlayerFacing directionFacing)
        {
            throw new System.NotImplementedException();
        }
    }
}