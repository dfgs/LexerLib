using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class Or : Predicate, IOr
	{
		[XmlIgnore]
		IEnumerable<IPredicate> IOr.Items => Items;
		public List<Predicate> Items
		{
			get;
			set;
		}


		public Or()
		{
			this.Items = new List<Predicate>();
		}
		public Or(params Predicate[] Items)
		{
			this.Items = new List<Predicate>(Items);
		}
	}
}
