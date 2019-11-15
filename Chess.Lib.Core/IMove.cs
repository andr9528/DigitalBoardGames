﻿using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IMove : IEntity
    {
        ICoordinate From { get; }
        ICoordinate To { get; set; }
        int CoordinateToId { get; set; }
        int Turn { get; set; }
        IPiece Piece { get; set; }
        int PieceId { get; set; }
    }
}