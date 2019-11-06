using System.Collections.Generic;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IRuleSet : IEntity
    {
        ICollection<IRule> Rules { get; set; }

        SetType Type { get; set; }
        string TypeName { get; set; }
    }
}