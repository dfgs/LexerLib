using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class Perhaps : Predicate, IPerhaps
	{
		[XmlIgnore]
		IPredicate IPerhaps.Item => Item;
		public Predicate Item
		{
			get;
			set;
		}


		public Perhaps()
		{
			
		}
		public Perhaps(Predicate Item)
		{
			this.Item = Item;
		}

		public override string ToString()
		{
			return $"{Item}?";
		}

	}
}
