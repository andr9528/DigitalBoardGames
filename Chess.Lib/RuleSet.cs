using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;

namespace Chess.Lib.Concrete
{
    public class RuleSet : IRuleSet
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public List<IRule> Rules { get; set; }
        public SetType Type { get; set; }
        public string TypeName { get; set; }
    }
}