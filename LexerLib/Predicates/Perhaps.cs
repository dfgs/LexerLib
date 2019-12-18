using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class Perhaps : Predicate, IPerhaps
	{
		IPredicate IPerhaps.Item => Item;
		public IPredicate Item
		{
			get;
			set;
		}


		public Perhaps()
		{
			
		}
		public Perhaps(IPredicate Item)
		{
			this.Item = Item;
		}
	}
}
