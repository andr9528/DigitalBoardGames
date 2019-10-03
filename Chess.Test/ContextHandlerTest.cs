using System;
using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Boards;
using Chess.Lib.Concrete.Pieces;
using Chess.Repository.Core;
using Chess.Repository.EntityFramework;
using Xunit;

namespace Chess.Test
{
    public class ContextHandlerTest
    {
        //[Fact]
        //public void Test1()
        //{
        //    // Arrange
        //    var sut = GetHandler();

        //    // Act


        //    // Assert

        //}
        #region CRUD --> C
        [Fact]
        public void InsertPawn()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new Pawn(new TwoPlayers(), sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertKnight()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new Knight(new TwoPlayers(), sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertRook()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new Rook(new TwoPlayers(), sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertBishops()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new Bishops(new TwoPlayers(), sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertQueen()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new Queen(new TwoPlayers(), sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertKing()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new King(new TwoPlayers(), sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertTwoPlayerBoard()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new TwoPlayers(sut, "Player1", "Player2"));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertGame()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new Game(sut));
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void InsertRuleSet()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            var actual = sut.Add(new RuleSet());
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void InsertField()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Field());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertRule()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Rule());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertPlayer()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Player());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        #endregion

        private protected IGenericRepository GetHandler()
        {
            using var factory = new ContextFactory();
            var context = factory.CreateMemoryContext<ChessRepository>();
            var handler = new GenericRepositoryHandler(context);
            return handler;
        }
    }
}
