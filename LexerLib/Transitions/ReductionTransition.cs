using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Transitions
{
	public class ReductionTransition : Transition, IReductionTransition
	{
		public string Name
		{
			get;
			set;
		}
		public ReductionTransition()
		{

		}

		public ReductionTransition(string Name)
		{
			this.Name = Name;
		}

	}
}
