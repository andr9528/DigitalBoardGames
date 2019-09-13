using System.Collections.Generic;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IBoard : IEntity   
    {
        List<IRule> Rules { get; set; }
    }
}