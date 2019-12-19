using LexerLib.Predicates;
using LexerLib.Situations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Transitions
{
	public class ShiftTransition : BaseTransition, IShiftTransition
	{
		IShiftPredicate IShiftTransition.Predicate => Predicate;
		public IShiftPredicate Predicate
		{
			get;
			set;
		}

		ISituation IShiftTransition.TargetSituation => TargetSituation;
		public ISituation TargetSituation
		{
			get;
			set;
		}



	}
}
