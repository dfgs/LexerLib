using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class ZeroOrMoreTimes : Predicate, IZeroOrMoreTimes
	{
		IPredicate IZeroOrMoreTimes.Item => Item;
		public IPredicate Item
		{
			get;
			set;
		}


		public ZeroOrMoreTimes()
		{
			
		}
		public ZeroOrMoreTimes(IPredicate Item)
		{
			this.Item = Item;
		}
	}
}
