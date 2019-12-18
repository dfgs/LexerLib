using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class Or : Predicate, IOr
	{
		IEnumerable<IPredicate> IOr.Items => Items;
		public List<IPredicate> Items
		{
			get;
			set;
		}


		public Or()
		{
			this.Items = new List<IPredicate>();
		}
		public Or(params IPredicate[] Items)
		{
			this.Items = new List<IPredicate>(Items);
		}
	}
}
