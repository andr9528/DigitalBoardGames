using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete
{
    public class Game : IGame
    {
        private readonly IGenericRepository _handler;
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public IBoard Board { get; set; }
        public int BoardId { get; set; }
        public IRuleSet RuleSet { get; set; }
        public int RuleSetId { get; set; }
        public int Turn { get; set; }
        public bool GameOver { get; set; }

        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="board"></param>
        public Game(IGenericRepository handler, IBoard board)
        {
            _handler = handler;
            Board = board;
            IsInstantiated = true;

            var rules = new List<IRule>()
            {

            };

            RuleSet = new RuleSet(typeof(Game), rules) {Type = SetType.Game};
        }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public Game()
        {
            
        }
        public bool HandleTurn(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyMove(IMove move, PlayerFacing directionFacing)
        {
            throw new System.NotImplementedException();
        }
    }
}