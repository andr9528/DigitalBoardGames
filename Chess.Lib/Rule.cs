using Chess.Lib.Core;
using Chess.Lib.Enum;

namespace Chess.Lib.Concrete
{
    public class Rule : IRule
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public RuleType Type { get; set; }
        public RuleMovement Movement { get; set; }
        public RuleMovement Attack { get; set; }
        public RuleDirection Direction { get; set; }
        public RuleCase Case { get; set; }
        public RuleObstruction Obstruction { get; set; }
        public RuleRequirement Requirement { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public int Value { get; set; }

        public Rule(string name, string description, string action) 
        {
            Description = description;
            Action = action;
            Name = name;
            IsInstantiated = true;
        }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public Rule()
        {
            
        }
    }
}