using Chess.Lib.Enum;
using Chess.Repository.Core;

namespace Chess.Lib.Core
{
    public interface IRule : IEntity
    {
        RuleAction Action { get; set; }
        RuleType Type { get; set; }
        RuleAxis Axis { get; set; }
        RuleDirection Direction { get; set; }
        string Description { get; set; }
        int LimitValue { get; set; }
    }
}