using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using LexerLib.Situations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Automatons
{
	[TestClass]
	public class AutomatonTableFactoryUnitTest
	{

		private bool ParseStates(State[] States,params char[] Inputs)
		{
			State currentState;
			int? nextIndex;

			currentState = States[0];
			foreach(char input in Inputs)
			{
				nextIndex = currentState.GetNextStateIndex(input);
				if (nextIndex == null) throw new InvalidOperationException("Failed to find next state");
				currentState = States[nextIndex.Value];
			}

			return true;
		}

		[TestMethod]
		public void ShouldNotBuildStatesAndThrowExceptions()
		{
			AutomatonTableFactory factory;

			factory = new AutomatonTableFactory();
			Assert.ThrowsException<ArgumentNullException>(() => factory.BuildStates(null));

		}


		[TestMethod]
		public void ShouldBuildStates()
		{
			AutomatonTableFactory factory;
			State[] states;
			SituationSegmentFactory segmentFactory;
			ISituation rootSituation;

			
			segmentFactory = new SituationSegmentFactory();

			rootSituation = segmentFactory.BuildRootSituation( 
				Parse.Character('a').ThenCharacter('b').ThenCharacter('c') , Parse.Character('a').ThenCharacter('b').ThenAnyCharacter()
				);

			factory = new AutomatonTableFactory();
			states=factory.BuildStates(rootSituation);

			Assert.AreEqual(5,states.Length);
			Assert.IsTrue(ParseStates(states, 'a', 'b', 'c'));
			Assert.IsTrue(ParseStates(states, 'a', 'b', 'd'));
		}

		[TestMethod]
		public void ShouldBuildStates2()
		{
			AutomatonTableFactory factory;
			State[] states;
			SituationSegmentFactory segmentFactory;
			ISituation rootSituation;


			segmentFactory = new SituationSegmentFactory();

			rootSituation = segmentFactory.BuildRootSituation(
				Parse.Character('a').Then(Parse.Character('b').OneOrMoreTimes()).ThenCharacter('c'), Parse.Character('a').ThenCharacter('b').ThenCharacter('e')
				);

			factory = new AutomatonTableFactory();
			states = factory.BuildStates(rootSituation);

			Assert.AreEqual(6, states.Length);
			Assert.IsTrue(ParseStates(states, 'a', 'b', 'b', 'b', 'c'));
			Assert.ThrowsException<InvalidOperationException>(()=>ParseStates(states, 'a', 'b', 'b', 'b', 'e'));
			Assert.IsTrue(ParseStates(states, 'a', 'b', 'e'));
		}

		[TestMethod]
		public void ShouldBuildStates3()
		{
			AutomatonTableFactory factory;
			State[] states;
			SituationSegmentFactory segmentFactory;
			ISituation rootSituation;


			segmentFactory = new SituationSegmentFactory();

			rootSituation = segmentFactory.BuildRootSituation(
				Parse.Character('a').Then(Parse.Character('b').ThenCharacter('b').ThenCharacter('b').Perhaps()).ThenCharacter('c'), Parse.Character('a').ThenCharacter('b').ThenCharacter('e')
				);

			factory = new AutomatonTableFactory();
			states = factory.BuildStates(rootSituation);

			Assert.AreEqual(7, states.Length);
			Assert.IsTrue(ParseStates(states, 'a', 'b', 'b', 'b', 'c'));
			Assert.IsTrue(ParseStates(states, 'a', 'c'));
			Assert.ThrowsException<InvalidOperationException>(() => ParseStates(states, 'a', 'b', 'b', 'b', 'e'));
			Assert.IsTrue(ParseStates(states, 'a', 'b', 'e'));
		}

	}
}
