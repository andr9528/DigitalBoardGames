using System;
using System.Collections.Generic;
using Chess.Lib.Concrete.Boards;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete.Pieces
{
    public class Rook : Piece
    {
        private readonly IGenericRepository _handler;

        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="board">The board that this piece will be on. Is used to look up its rules</param>
        /// <param name="handler"></param>
        public Rook(IBoard board, IGenericRepository handler) : base()
        {
            _handler = handler;
            var boardType = board.GetType();

            var rules = CreateRules(boardType);

            RuleSet = new RuleSet(typeof(Rook), rules) { Type = SetType.Piece };
        }
        
        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public Rook()
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