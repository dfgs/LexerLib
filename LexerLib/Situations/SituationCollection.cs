using LexerLib.Automatons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public class SituationCollection : ISituationCollection
	{
		IEnumerable<ISituation> ISituationCollection.Items => Items;
		public List<ISituation> Items
		{
			get;
			set;
		}
		IState ISituationCollection.State => State;
		public State State
		{
			get;
			set;
		}

		public SituationCollection()
		{
			Items = new List<ISituation>();
		}
	}
}
