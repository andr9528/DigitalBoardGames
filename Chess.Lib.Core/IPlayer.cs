using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IPlayer : IEntity
    {
        PlayerColour Colour { get; set; }
        List<IPiece> Pieces { get; set; }
        PlayerFacing Facing { get; set; }
        string Name { get; set; }

    }
}