using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class OneOrMoreTimes : Predicate, IOneOrMoreTimes
	{
		[XmlIgnore]
		IPredicate IOneOrMoreTimes.Item => Item;
		public Predicate Item
		{
			get;
			set;
		}


		public OneOrMoreTimes()
		{
			
		}
		public OneOrMoreTimes(Predicate Item)
		{
			this.Item = Item;
		}
	}
}
