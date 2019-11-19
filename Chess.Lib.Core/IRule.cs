using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Core
{
    public interface IRule : IEntity
    {
        RuleType Type { get; set; }
        RuleMovement Movement { get; set; }
        RuleMovement Attack { get; set; }
        RuleDirection Direction { get; set; }
        RuleCase Case { get; set; }
        RuleObstruction Obstruction { get; set; }
        RuleRequirement Requirement { get; set; }
        string Description { get; set; }
        string Target { get; set; }
        string Name { get; set; }
        string Action { get; set; }
        int Value { get; set; }
    }
}