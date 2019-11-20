using System;
using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;

namespace Chess.Lib.Concrete
{
    public class RuleSet : IRuleSet
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsInstantiated { get; set; }
        public ICollection<IRule> Rules { get; set; }
        public SetType Type { get; set; }
        public string TypeName { get; set; }
        public string BoardTypeName { get; set; }


        public RuleSet(Type boardType, List<IRule> rules, Type type = null)
        {
            if (rules == null) throw new ArgumentNullException(nameof(rules));
            //if (rules.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(rules));

            Rules = rules;
            if (type != null) TypeName = type.Name;
            BoardTypeName = boardType.Name;
            IsInstantiated = true;
        }


        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public RuleSet()
        {

        }
    }
}