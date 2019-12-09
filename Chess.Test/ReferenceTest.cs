using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Boards;
using Chess.Lib.Core;
using Chess.Repository.EntityFramework;
using Repository.Core;
using Utilities.Factories;
using Xunit;

namespace Chess.Test
{
    public class ReferenceTest
    {
        /// <summary>
        /// Given a piece and Fields that contain Pieces.
        /// Find the piece on the field with the same coordinate as the given piece.
        /// Verify that these two pieces are indeed the same reference.
        /// If they are not the same, then somewhere a duplicate of a piece is created, where a reference should exist.
        /// </summary>
        [Fact]
        public void ReferenceSamePieceFromFieldAndPlayerBoard()
        {
            // Arrange
            var handler = ContextFactory.GetChessHandler();
            var sut = new Game(handler, typeof(TwoPlayers), new Player() {Name = "Player1"},
                new Player() {Name = "Player2"});

            // Act
            var fields = (List<IField>)sut.Board.Fields;
            var pieces = new List<IPiece>();
            foreach (var player in sut.Board.Players)
                pieces.AddRange(player.Pieces);
            
            var actual = new List<bool>();

            foreach (var piece in pieces)
            {
                actual.Add(ReferenceEquals(piece,
                    fields.First(x => x.Coordinate.X == piece.Field.Field.Coordinate.X &&
                                      x.Coordinate.Y == piece.Field.Field.Coordinate.Y).Piece.Piece));
            }

            // Assert
            Assert.True(!actual.Exists(x => x == false));

        }
    }
}