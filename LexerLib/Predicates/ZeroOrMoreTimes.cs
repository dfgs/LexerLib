using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class ZeroOrMoreTimes : Predicate, IZeroOrMoreTimes
	{
		[XmlIgnore]
		IPredicate IZeroOrMoreTimes.Item => Item;
		public Predicate Item
		{
			get;
			set;
		}


		public ZeroOrMoreTimes()
		{
			
		}
		public ZeroOrMoreTimes(Predicate Item)
		{
			this.Item = Item;
		}
	}
}
