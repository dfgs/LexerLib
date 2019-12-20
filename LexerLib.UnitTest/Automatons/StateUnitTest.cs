using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Automatons
{
	[TestClass]
	public class StateUnitTest
	{
		[TestMethod]
		public void ShouldCreateShift()
		{
			State state;
			int? nextIndex;


			state = new State();
	
			nextIndex = state.GetNextStateIndex('a');
			Assert.IsNull(nextIndex);

			state.CreateShift('a', 1);

			nextIndex = state.GetNextStateIndex('a');
			Assert.AreEqual(1,nextIndex);


		}




	}
}
