using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete.Pieces
{
    public class King : Piece
    {
        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="board">The board that this piece will be on. Is used to look up its rules</param>
        /// <param name="handler"></param>
        public King(IBoard board, IGenericRepository handler) : base()
        {
            var boardType = board.GetType();

            SetupRuleSet(handler, GetType(), boardType);
        }
        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public King()
        {

        }
        public override bool VerifyMove(IMove move, PlayerFacing directionFacing)
        {
            throw new System.NotImplementedException();
        }

        protected override List<IRule> TwoPlayerRules()
        {
            var rules = new List<IRule>()
            {

            };

            return rules;
        }
    }
}