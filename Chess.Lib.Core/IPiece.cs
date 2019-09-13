using System.Collections.Generic;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IPiece : IEntity
    {
        List<IMove> MoveHistory { get; set; }
        List<IRule> Rules { get; set; }


        bool VerifyMove(IMove move);
    }
}