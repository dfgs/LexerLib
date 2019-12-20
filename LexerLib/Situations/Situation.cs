using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public class Situation : ISituation
	{
		IEnumerable<ITransition> ISituation.Transitions => Transitions;
		public List<ITransition> Transitions
		{
			get;
			set;
		}

		public Situation()
		{
			this.Transitions = new List<ITransition>();
		}

		
	}
}
