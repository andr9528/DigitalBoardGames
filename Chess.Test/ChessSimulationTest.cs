using System;
using System.Collections.Generic;
using System.Text;
using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Boards;
using Chess.Lib.Core;
using Repository.Core;
using Utilities.Extensions.Test;
using Utilities.Factories;
using Xunit;

namespace Chess.Test
{
    public class ChessSimulationTest
    {
        private IGenericRepository _handler;
        private IGame _game;
        private int _testTurnCounter = 0;

        private void ChessSetup()
        {
            // Arrange
            _handler = ContextFactory.GetChessHandler();
            _testTurnCounter = 1;

            // Act
            var actual = _handler.Add(new Game(_handler, typeof(TwoPlayers), new Player() { Name = "Player1" }, new Player() { Name = "Player2" }));
            _handler.Save();

            _game = _handler.Find(new Game() {Id = 1, Turn = 0});

            // Assert
            Assert.True(actual);
            Assert.NotNull(_game);
            Assert.NotNull(_handler);
        }

        #region Game 1
        [Fact]
        public void ChessSimulationNumber1()
        {
            ChessSetup();

            Turn1InvalidMove1();
            Turn1ValidMove();
        }

        private void Turn1InvalidMove1()
        {
            // Arrange

            try
            {
                // Act  
                
            }
            catch (Exception)
            {
                // Assert
                
            }
        }
        private void Turn1ValidMove()
        {
            // Arrange

            // Act

            _testTurnCounter++;

            // Assert
            Assert.Equal(_testTurnCounter, _game.Turn);
        }
        #endregion

        //private void Turn_InvalidMove_()
        //{
        //    // arrange

        //    try
        //    {
        //        // Act  

        //    }
        //    catch (Exception)
        //    {
        //        // Assert

        //    }
        //}

        //private void Turn_ValidMove()
        //{
        //    // Arrange

        //    // Act

        //      _testTurnCounter++;

        //    // Assert
        //      Assert.Equal(_testTurnCounter, _game.Turn);
        //}
    }
}
    