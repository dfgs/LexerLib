using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	[XmlInclude(typeof(Character)), XmlInclude(typeof(AnyCharacter)), XmlInclude(typeof(OneOrMoreTimes)), XmlInclude(typeof(ZeroOrMoreTimes)), XmlInclude(typeof(Sequence)), XmlInclude(typeof(Perhaps)), XmlInclude(typeof(Or))]
	public abstract class Predicate:IPredicate
	{


	}
}
