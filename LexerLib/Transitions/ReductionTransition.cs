using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Transitions
{
	public class ReductionTransition : Transition, IReductionTransition
	{
		public IRule Rule
		{
			get;
			set;
		}
		public ReductionTransition()
		{

		}

		public ReductionTransition(IRule Rule)
		{
			this.Rule = Rule;
		}

	}
}
