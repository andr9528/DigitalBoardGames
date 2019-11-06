using System.Collections.Generic;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IPlayer : IEntity
    {
        string Name { get; set; }
        ICollection<IPlayerBoard> Boards { get; set; }
    }
}