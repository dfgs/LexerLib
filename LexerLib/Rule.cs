using LexerLib.Predicates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib
{
    [Serializable]
    public class Rule : IRule
    {
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        [XmlIgnore]
        IPredicate IRule.Predicate => Predicate;
        
        public Predicate Predicate
        {
            get;
            set;
        }

        public Rule()
        {

        }
        public Rule(string Name,Predicate Predicate)
        {
            this.Name = Name;
            this.Predicate = Predicate;
        }

       

    }
}
