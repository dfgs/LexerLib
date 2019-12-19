using LexerLib.Predicates;
using LexerLib.Situations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Transitions
{
	public interface IShiftTransition:ITransition
	{
		IShiftPredicate Predicate
		{
			get;
		}

		ISituation TargetSituation
		{
			get;
		}
	}
}
