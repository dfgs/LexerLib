using LexerLib.Predicates;
using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public interface ISituationFactory
	{
		ISituation BuildRootSituation(IPredicate Predicate);
		//ITransition[] BuildTransitions(IPredicate Predicate, ITransition[] OutTransitions);
		ITransition[] BuildTransitions(IShiftPredicate Predicate, ITransition[] OutTransitions);
		ITransition[] BuildTransitions(ISequence Predicate, ITransition[] OutTransitions);
		ITransition[] BuildTransitions(IOr Predicate, ITransition[] OutTransitions);
		ITransition[] BuildTransitions(IPerhaps Predicate, ITransition[] OutTransitions);
		ITransition[] BuildTransitions(IOneOrMoreTimes Predicate, ITransition[] OutTransitions);
		ITransition[] BuildTransitions(IZeroOrMoreTimes Predicate, ITransition[] OutTransitions);


	}

}
