using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete
{
    public class PlayerBoard : IPlayerBoard
    {
        private readonly IGenericRepository _handler;
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public PlayerColour Colour { get; set; }
        public ICollection<IPiece> Pieces { get; set; }
        public PlayerFacing Facing { get; set; }
        public IBoard Board { get; set; }
        public IPlayer Player { get; set; }
        public int BoardId { get; set; }
        public int PlayerId { get; set; }

        public PlayerBoard(IGenericRepository handler, IBoard board)
        {
            _handler = handler;
            IsInstantiated = true;
        }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public PlayerBoard()
        {

        }
    }
}