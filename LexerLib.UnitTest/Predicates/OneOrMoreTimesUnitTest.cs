using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class OneOrMoreTimesUnitTest
	{
		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.Character('a').OneOrMoreTimes();
			Assert.AreEqual("a+", predicate.ToString());
		}

		




	}
}
