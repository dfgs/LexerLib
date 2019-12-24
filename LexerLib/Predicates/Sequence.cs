using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class Sequence : Predicate, ISequence
	{
		[XmlIgnore]
		IEnumerable<IPredicate> ISequence.Items => Items;
		public List<Predicate> Items
		{
			get;
			set;
		}


		public Sequence()
		{
			this.Items = new List<Predicate>();
		}
		public Sequence(params Predicate[] Items)
		{
			this.Items = new List<Predicate>(Items);
		}
	}
}
