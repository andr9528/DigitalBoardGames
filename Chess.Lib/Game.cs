﻿using Chess.Lib.Core;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Concrete
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public IBoard Board { get; set; }
        public IRuleSet RuleSet { get; set; }
        public int Turn { get; set; }

        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="handler"></param>
        public Game(IGenericRepository handler)
        {
            
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