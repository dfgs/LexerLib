using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class OneOrMoreTimes : Predicate, IOneOrMoreTimes
	{
		IPredicate IOneOrMoreTimes.Item => Item;
		public IPredicate Item
		{
			get;
			set;
		}


		public OneOrMoreTimes()
		{
			
		}
		public OneOrMoreTimes(IPredicate Item)
		{
			this.Item = Item;
		}
	}
}
