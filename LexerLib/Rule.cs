using LexerLib.Predicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
    public class Rule : IRule
    {
        public string Name
        {
            get;
            set;
        }

        IPredicate IRule.Predicate => Predicate;
        public Predicate Predicate
        {
            get;
            set;
        }

        public Rule()
        {

        }
        
    }
}
