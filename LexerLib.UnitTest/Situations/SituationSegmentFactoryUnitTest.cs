using System;
using System.Collections.Generic;
using System.Linq;
using LexerLib.Predicates;
using LexerLib.Situations;
using LexerLib.Transitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Situations
{
	[TestClass]
	public class SituationSegmentFactoryUnitTest
	{
		private bool ParseSegment(ISituationSegment Segment, params Type[] PredicateTypes)
		{
			return ParseSegment(Segment.InputTransitions,PredicateTypes);
		}
		private bool ParseSegment(IEnumerable<ITransition> Transitions , params Type[] PredicateTypes)
		{
			IEnumerable<ITransition> transitions;
			IShiftTransition transition;
			IReductionTransition reductionTransition;

			transitions = Transitions;

			for (int t = 0; t < PredicateTypes.Length; t++)
			{
				transition = transitions.OfType<IShiftTransition>().FirstOrDefault(item => item.Predicate.GetType() == PredicateTypes[t]);
				if (transition == null) throw new Exception($"Failed to find shift transition with predicate type {PredicateTypes[t]}");
				transitions = transition.TargetSituation.Transitions;
			}
			reductionTransition = transitions.OfType<IReductionTransition>().FirstOrDefault();
			if (reductionTransition == null) throw new Exception($"Failed to find reduction transition");

			return true;
		}




		[TestMethod]
		public void ShouldBuildRootSituation()
		{
			IPredicate predicate;
			ISituation situation;
			ISituationSegmentFactory factory;

			predicate = Parse.Character('a');

			factory = new SituationSegmentFactory();
			situation=factory.BuildRootSituation(predicate);
			Assert.IsNotNull(situation);
			Assert.IsTrue(ParseSegment(situation.Transitions, typeof(Character)));

		}
		[TestMethod]
		public void ShouldNotBuildRootSituationAndThrowException()
		{
			ISituationSegmentFactory factory;


			factory = new SituationSegmentFactory();
			Assert.ThrowsException<ArgumentNullException>(()=> factory.BuildRootSituation(null));

		}

		[TestMethod]
		public void ShouldNotBuildSituationSegmentAndThrowException()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;

			predicate = Parse.Character('a');

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			Assert.ThrowsException<ArgumentNullException>(() => factory.BuildSituationSegment(predicate, null));
			Assert.ThrowsException<ArgumentNullException>(() => factory.BuildSituationSegment(null, nextSegment));
		}


		[TestMethod]
		public void ShouldBuildSituationSegmentUsingCharacterPredicate()
		{
			IPredicate predicate;
			SituationSegment nextSegment; 
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.Character('a');
			
			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment=factory.BuildSituationSegment(predicate, nextSegment);
						
			Assert.IsTrue( ParseSegment(segment, typeof(Character)));
		}
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingAnyCharacterPredicate()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.AnyCharacter();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter)));
		}
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingSequence()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.AnyCharacter().ThenCharacter('a').ThenCharacter('b');

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter), typeof(Character), typeof(Character)));
		}
		
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingOr()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.AnyCharacter().OrCharacter('a');

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter)));
			Assert.IsTrue(ParseSegment(segment, typeof(Character)));
		}
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingPerhaps()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.AnyCharacter().Perhaps();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter)));
			Assert.IsTrue(ParseSegment(segment));
		}
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingOneOrMoreTimes()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.Character('a').OneOrMoreTimes();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.ThrowsException<Exception>(()=>ParseSegment(segment));
			Assert.IsTrue(ParseSegment(segment, typeof(Character), typeof(Character), typeof(Character)));
		}
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingZeroOrMoreTimes()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			predicate = Parse.Character('a').ZeroOrMoreTimes();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment));
			Assert.IsTrue(ParseSegment(segment, typeof(Character), typeof(Character), typeof(Character)));
		}
		[TestMethod]
		public void ShouldBuildSituationSegmentUsingComplexPredicate()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;
			ISituationSegment segment;

			#region or inside a sequence
			predicate = Parse.AnyCharacter().Then(Parse.Character('a').OrCharacter('b')).ThenAnyCharacter();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter), typeof(Character), typeof(AnyCharacter)));
			#endregion

			#region optional sequence in sequence
			predicate = Parse.AnyCharacter().Then(Parse.Character('a').ThenCharacter('b').Perhaps()).ThenAnyCharacter();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter), typeof(Character), typeof(Character), typeof(AnyCharacter)));
			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter), typeof(AnyCharacter)));
			#endregion

			#region one or more inside a sequence
			predicate = Parse.AnyCharacter().Then(Parse.Character('b').OneOrMoreTimes()).ThenAnyCharacter();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			segment = factory.BuildSituationSegment(predicate, nextSegment);

			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter), typeof(Character), typeof(AnyCharacter)));
			Assert.IsTrue(ParseSegment(segment, typeof(AnyCharacter), typeof(Character), typeof(Character), typeof(Character), typeof(AnyCharacter)));
			#endregion

	
		}













		[TestMethod]
		public void ShouldNotBuildSituationSegmentUsingInvalidSequence()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;

			predicate = new Sequence();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			Assert.ThrowsException<InvalidOperationException>(() => factory.BuildSituationSegment(predicate, nextSegment));

		}

		[TestMethod]
		public void ShouldNotBuildSituationSegmentUsingInvalidOr()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;

			predicate = new Or();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			Assert.ThrowsException<InvalidOperationException>(() => factory.BuildSituationSegment(predicate, nextSegment));

		}
		[TestMethod]
		public void ShouldNotBuildSituationSegmentUsingInvalidPerhaps()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;

			predicate = new Perhaps();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			Assert.ThrowsException<InvalidOperationException>(() => factory.BuildSituationSegment(predicate, nextSegment));

		}
		[TestMethod]
		public void ShouldNotBuildSituationSegmentUsingInvalidOneOrMoreTimes()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;

			predicate = new OneOrMoreTimes();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			Assert.ThrowsException<InvalidOperationException>(() => factory.BuildSituationSegment(predicate, nextSegment));

		}
		[TestMethod]
		public void ShouldNotBuildSituationSegmentUsingInvalidZeroOrMoreTimes()
		{
			IPredicate predicate;
			SituationSegment nextSegment;
			ISituationSegmentFactory factory;

			predicate = new ZeroOrMoreTimes();

			nextSegment = new SituationSegment();
			nextSegment.InputTransitions.Add(new ReductionTransition());

			factory = new SituationSegmentFactory();
			Assert.ThrowsException<InvalidOperationException>(() => factory.BuildSituationSegment(predicate, nextSegment));

		}




	}
}
