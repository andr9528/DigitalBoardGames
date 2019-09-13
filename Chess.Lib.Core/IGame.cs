using System.Collections.Generic;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IGame : IEntity
    {
        IBoard Board { get; set; }
        List<IPlayer> Players { get; set; }
        List<IRule> Rules { get; set; }
        int Turn { get; set; }

        bool HandleTurn(IPlayer player);
    }
}