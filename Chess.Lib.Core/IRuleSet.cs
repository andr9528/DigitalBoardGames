using System.Collections.Generic;
using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IRuleSet : IEntity
    {
        List<IRule> Rules { get; set; }

        SetType Type { get; set; }
        string TypeName { get; set; }
    }
}