using LexerLib.Predicates;
using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public class SituationSegmentFactory : ISituationSegmentFactory
	{
		public SituationSegmentFactory()
		{
		}

		#region ISituationSegmentFactory implicit definition
		ISituation ISituationSegmentFactory.BuildRootSituation(params IRule[] Rules)
		{
			return BuildRootSituation(Rules);
		}

		ISituationSegment ISituationSegmentFactory.BuildSituationSegment(IPredicate Predicate, ISituationSegment NextSegment)
		{
			return BuildSituationSegment(Predicate, NextSegment);
		}
		#endregion

		public ISituation BuildRootSituation(params IRule[] Rules)
		{
			Situation root;
			SituationSegment nextSegment;
			ISituationSegment segment;

			if (Rules == null) throw new ArgumentNullException("Rules");

			root = new Situation();

			foreach (IRule rule in Rules)
			{
				nextSegment = new SituationSegment();
				nextSegment.InputTransitions.Add(new ReductionTransition(rule));

				segment = BuildSituationSegment(rule.Predicate, nextSegment);
				root.Transitions.AddRange(segment.InputTransitions);
			}

			return root;
		}

		private SituationSegment BuildSituationSegment(IPredicate Predicate,ISituationSegment NextSegment)
		{

			if (Predicate == null) throw new ArgumentNullException("Predicate");
			if (NextSegment == null) throw new ArgumentNullException("NextSegment");

			switch (Predicate)
			{
				case IShiftPredicate shiftPredicate:
					return BuildSituationSegment(shiftPredicate, NextSegment);
				case ISequence sequencePredicate:
					return BuildSituationSegment(sequencePredicate, NextSegment);
				case IOr orPredicate:
					return BuildSituationSegment(orPredicate, NextSegment);
				case IPerhaps perhapsPredicate:
					return BuildSituationSegment(perhapsPredicate, NextSegment);
				case IOneOrMoreTimes oneOrMoreTimesPredicate:
					return BuildSituationSegment(oneOrMoreTimesPredicate, NextSegment);
				case IZeroOrMoreTimes zeroOrMoreTimesPredicate:
					return BuildSituationSegment(zeroOrMoreTimesPredicate, NextSegment);
				default:
					throw new InvalidOperationException($"Invalid predicate type: {Predicate.GetType().Name}");
			}
		}

		private SituationSegment BuildSituationSegment(IShiftPredicate Predicate, ISituationSegment NextSegment)
		{
			Situation situation;
			ShiftTransition transition;
			SituationSegment result;

			situation = new Situation();
			situation.Transitions.AddRange(NextSegment.InputTransitions);

			transition = new ShiftTransition();
			transition.Predicate = Predicate;
			transition.TargetSituation = situation;

			result = new SituationSegment();
			result.InputTransitions.Add(transition);
			result.OutputSituations.Add(situation);

			return result;
		}
		private SituationSegment BuildSituationSegment(ISequence Predicate, ISituationSegment NextSegment)
		{
			IPredicate[] predicates;
			ISituationSegment[] segments;
			ISituationSegment lastSegment;
			SituationSegment result;

			if ((Predicate.Items == null) || (!Predicate.Items.Any())) throw new InvalidOperationException("Invalid sequence predicate");
			

			lastSegment = NextSegment;
			predicates = Predicate.Items.ToArray();
			segments = new SituationSegment[predicates.Length];

			for(int t=predicates.Length-1;t>=0;t--)
			{
				segments[t] = BuildSituationSegment(predicates[t], lastSegment);
				lastSegment = segments[t];
			}

			result = new SituationSegment();
			result.InputTransitions.AddRange(segments.First().InputTransitions);
			result.OutputSituations.AddRange(segments.Last().OutputSituations);

			return result;
		}

		private SituationSegment BuildSituationSegment(IOr Predicate, ISituationSegment NextSegment)
		{
			List<ISituationSegment> segments;
			SituationSegment result;

			if ((Predicate.Items == null) || (!Predicate.Items.Any())) throw new InvalidOperationException("Invalid or predicate");

			segments = new List<ISituationSegment>();
			foreach (IPredicate item in Predicate.Items)
			{
				segments.Add(BuildSituationSegment(item, NextSegment));
			}

			result = new SituationSegment();
			result.InputTransitions.AddRange(segments.SelectMany(item => item.InputTransitions));
			result.OutputSituations.AddRange(segments.SelectMany(item => item.OutputSituations));

			return result;
		}

		private SituationSegment BuildSituationSegment(IPerhaps Predicate, ISituationSegment NextSegment)
		{
			SituationSegment result;

			if (Predicate.Item == null)  throw new InvalidOperationException("Invalid perhaps predicate");

			result = BuildSituationSegment(Predicate.Item, NextSegment);
			result.InputTransitions.AddRange(NextSegment.InputTransitions);
			//result.OutputSituations.AddRange(NextSegment.OutputSituations);

			return result;
		}

		private SituationSegment BuildSituationSegment(IOneOrMoreTimes Predicate, ISituationSegment NextSegment)
		{
			SituationSegment result;

			if (Predicate.Item == null) throw new InvalidOperationException("Invalid one or more times predicate");

			result = BuildSituationSegment(Predicate.Item, NextSegment);
			foreach(Situation situation in result.OutputSituations)
			{
				situation.Transitions.AddRange(result.InputTransitions);
			}
			return result;
		}

		private SituationSegment BuildSituationSegment(IZeroOrMoreTimes Predicate, ISituationSegment NextSegment)
		{
			SituationSegment result;

			if (Predicate.Item == null) throw new InvalidOperationException("Invalid zero or more times predicate");

			result = BuildSituationSegment(Predicate.Item, NextSegment);
			foreach (Situation situation in result.OutputSituations)
			{
				situation.Transitions.AddRange(result.InputTransitions);
			}
			result.InputTransitions.AddRange(NextSegment.InputTransitions);

			return result;
		}



	}
}
