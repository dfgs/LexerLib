using LexerLib.Predicates;
using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public class SituationFactory : ISituationFactory
	{
		public ISituation BuildRootSituation(IPredicate Predicate)
		{
			Situation root;
			ReductionTransition reductionTransition;

			reductionTransition = new ReductionTransition();
			root = new Situation();
			root.Transitions.AddRange(BuildTransitions(Predicate,new ITransition[] { reductionTransition }));

			return root;
		}

		private ITransition[] BuildTransitions(IPredicate Predicate, ITransition[] OutTransitions)
		{
			switch(Predicate)
			{
				case IShiftPredicate shiftPredicate:
					return BuildTransitions(shiftPredicate, OutTransitions);
				case ISequence sequencePredicate:
					return BuildTransitions(sequencePredicate, OutTransitions);
				case IOr orPredicate:
					return BuildTransitions(orPredicate, OutTransitions);
				case IPerhaps perhapsPredicate:
					return BuildTransitions(perhapsPredicate, OutTransitions);
				case IOneOrMoreTimes oneOrMoreTimesPredicate:
					return BuildTransitions(oneOrMoreTimesPredicate, OutTransitions);
				case IZeroOrMoreTimes zeroOrMoreTimesPredicate:
					return BuildTransitions(zeroOrMoreTimesPredicate, OutTransitions);
				default:
					throw new InvalidOperationException($"Invalid predicate type: {Predicate.GetType().Name}");
			}
		}

		public ITransition[] BuildTransitions(IShiftPredicate Predicate, ITransition[] OutTransitions)
		{
			Situation situation;
			ShiftTransition transition;

			situation = new Situation();
			transition = new ShiftTransition();
			transition.Predicate = Predicate;
			transition.TargetSituation = situation;

			return new ITransition[] { transition };
		}
		public ITransition[] BuildTransitions(ISequence Predicate, ITransition[] OutTransitions)
		{
			ITransition[] outTransitions;


			outTransitions = OutTransitions;
			foreach(IPredicate item in Predicate.Items.Reverse())
			{
				outTransitions = BuildTransitions(item, outTransitions);
			}

			return outTransitions;
		}
		public ITransition[] BuildTransitions(IOr Predicate, ITransition[] OutTransitions)
		{
			List<ITransition> outTransitions;


			outTransitions = new List<ITransition>();
			foreach (IPredicate item in Predicate.Items)
			{
				outTransitions.AddRange(BuildTransitions(item, OutTransitions));
			}

			return outTransitions.ToArray();
		}

		public ITransition[] BuildTransitions(IPerhaps Predicate, ITransition[] OutTransitions)
		{
			List<ITransition> outTransitions;


			outTransitions = new List<ITransition>();
			outTransitions.AddRange(BuildTransitions(Predicate.Item, OutTransitions));
			outTransitions.AddRange(OutTransitions);

			return outTransitions.ToArray();
		}

		public ITransition[] BuildTransitions(IOneOrMoreTimes Predicate, ITransition[] OutTransitions)
		{
			List<ITransition> outTransitions;


			outTransitions = new List<ITransition>();
			outTransitions.AddRange(BuildTransitions(Predicate.Item, OutTransitions));
			outTransitions.AddRange(OutTransitions);

			return outTransitions.ToArray();
		}


	}
}
