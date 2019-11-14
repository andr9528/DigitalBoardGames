using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Boards;
using Chess.Lib.Concrete.Pieces;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Chess.Repository.EntityFramework;
using Repository.Core;
using Utilities.Factories;
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
        #region CRUD
        #region Create
        [Fact]
        public void InsertPawn()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Pawn(new TwoPlayers(), sut));

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertKnight()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Knight(new TwoPlayers(), sut));

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertRook()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Rook(new TwoPlayers(), sut));

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertBishops()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Bishop(new TwoPlayers(), sut));

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertQueen()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Queen(new TwoPlayers(), sut));

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertKing()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new King(new TwoPlayers(), sut));

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertTwoPlayerBoard()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new TwoPlayers(sut, new Player(){ Name = "Player1"}, new Player() { Name = "Player2" }));
            sut.Save();

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertPlayerBoard()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new PlayerBoard());
            sut.Save();

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void InsertGame()
        {
            // Arrange
            var sut = GetHandler();
            var board = new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" });

            // Act
            var actual = sut.Add(new Game(sut, board));
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
        [Fact]
        public void InsertCoordinate()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Add(new Coordinate());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        #endregion

        #region Read
        [Fact]
        public void FindPawn()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();


            // Act
            var actual = sut.FindMultiple(new Pawn() { PlayerBoardId = 1 }).First();

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadKnight()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();


            // Act
            var actual = sut.FindMultiple(new Knight() { PlayerBoardId = 1 }).First();

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadRook()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();


            // Act
            var actual = sut.FindMultiple(new Rook() { PlayerBoardId = 1 }).First();

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadBishops()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();

            // Act
            var actual = sut.FindMultiple(new Bishop() { PlayerBoardId = 1 }).First();

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadQueen()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();

            // Act
            var actual = sut.Find(new Queen() { PlayerBoardId = 1 });

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadKing()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();


            // Act
            var actual = sut.Find(new King() {PlayerBoardId = 1});

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadTwoPlayerBoard()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();

            // Act
            var actual = sut.Find(new TwoPlayers() {GameId = 1});

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadPlayerBoard()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();

            // Act
            var actual = sut.Find(new PlayerBoard() {BoardId = 1, PlayerId = 1});

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadGame()
        {
            // Arrange
            var sut = GetHandler();
            var board = new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" });
            sut.Add(new Game(sut, board));
            sut.Save();

            // Act
            var actual = sut.Find(new Game() {Board = board, Turn = 0});

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void ReadRuleSet()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new King(new TwoPlayers(), sut));
            sut.Save();

            // Act
            var actual = sut.Find(new RuleSet() {Type = SetType.Piece, TypeName = nameof(King)});

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadPlayer()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();

            // Act
            var actual = sut.Find(new Player() {Name = "Player2" });

            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void ReadField()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Find(new Field());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void ReadRule()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Find(new Rule());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        [Fact]
        public void ReadCoordinate()
        {
            // Arrange
            var sut = GetHandler();

            // Act
            Action actual = () => sut.Find(new Coordinate());

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }
        #endregion

        #region Update
        [Fact]
        public void UpdatePawn()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.FindMultiple(new Pawn() {PlayerBoardId = 1}).First();
            obj.Alive = false;

            // Act
            var actual = sut.Update(obj);

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateKnight()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.FindMultiple(new Knight() { PlayerBoardId = 1 }).First();
            obj.Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateRook()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.FindMultiple(new Rook() { PlayerBoardId = 1 }).First();
            obj.Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateBishops()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.FindMultiple(new Bishop() { PlayerBoardId = 1 }).First();
            obj.Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateQueen()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.Find(new Queen() { PlayerBoardId = 1 });
            obj.Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateKing()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.Find(new King() { PlayerBoardId = 1 });
            obj.Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();
            
            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateTwoPlayerBoard()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.Find(new TwoPlayers() {GameId = 1});
            ((List<IPiece>) obj.Players.First().Pieces).Find(x => x.Discriminator == nameof(Queen)).Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdatePlayerBoard()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.Find(new PlayerBoard() {BoardId = 1, PlayerId = 1});
            ((List<IPiece>) obj.Pieces).Find(x => x.Discriminator == nameof(Queen)).Alive = false;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdateGame()
        {
            // Arrange
            var sut = GetHandler();
            var board = new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" });
            sut.Add(new Game(sut, board));
            sut.Save();
            var obj = sut.Find(new Game() {Board = board, Turn = 0});
            obj.Turn = 666;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void UpdateRuleSet()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new King(new TwoPlayers(), sut));
            sut.Save();
            var obj = sut.Find(new RuleSet() { Type = SetType.Piece, TypeName = nameof(King) });
            obj.Type = SetType.Game;

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        [Fact]
        public void UpdatePlayer()
        {
            // Arrange
            var sut = GetHandler();
            sut.Add(new TwoPlayers(sut, new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            sut.Save();
            var obj = sut.Find(new Player() {Name = "Player1"});
            obj.Name = "ReadyPlayerOne";

            // Act
            var actual = sut.Update(obj);
            sut.Save();

            // Assert
            Assert.True(actual);
        }
        #endregion
        #endregion

        private IGenericRepository GetHandler()
        {
            using var factory = new ContextFactory();
            var handler = factory.GetHandler(factory.CreateMemoryContext<ChessRepository>());
            return handler;
        }
    }
}
