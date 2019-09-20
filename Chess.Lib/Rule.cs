using Chess.Lib.Core;
using Chess.Lib.Enum;

namespace Chess.Lib.Concrete
{
    public class Rule : IRule
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public RuleAction Action { get; set; }
        public RuleType Type { get; set; }
        public RuleAxis Axis { get; set; }
        public RuleDirection Direction { get; set; }
        public string Description { get; set; }
        public int LimitValue { get; set; }
    }
}