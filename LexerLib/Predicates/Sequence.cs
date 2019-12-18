using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class Sequence : Predicate, ISequence
	{
		IEnumerable<IPredicate> ISequence.Items => Items;
		public List<IPredicate> Items
		{
			get;
			set;
		}


		public Sequence()
		{
			this.Items = new List<IPredicate>();
		}
		public Sequence(params IPredicate[] Items)
		{
			this.Items = new List<IPredicate>(Items);
		}
	}
}
