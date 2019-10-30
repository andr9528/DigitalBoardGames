using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IPlayer : IEntity
    {
        string Name { get; set; }
        List<IPlayerBoard> Boards { get; set; }
    }
}