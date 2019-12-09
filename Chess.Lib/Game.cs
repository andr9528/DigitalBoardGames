using System;
using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public IBoard Board { get; set; }
        public IRuleSet RuleSet { get; set; }
        public int RuleSetId { get; set; }
        public int Turn { get; set; }
        public bool GameOver { get; set; }

        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="boardType"></param>
        /// <param name="players"></param>
        public Game(IGenericRepository handler, Type boardType, params Player[] players)
        {
            if (!typeof(IBoard).IsAssignableFrom(boardType))
                throw new ArgumentException("The Board type supplied is not assignable from IBoard", nameof(boardType));
            
            Board = Activator.CreateInstance(boardType, handler, this, players) as IBoard;

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