﻿using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IField : IEntity
    {
        ICoordinate Coordinate { get; set; }
        int CoordinateId { get; set; }
        IPiece Piece { get; set; }
        int PieceId { get; set; }
        IBoard Board { get; set; }
        int BoardId { get; set; }
    }
}