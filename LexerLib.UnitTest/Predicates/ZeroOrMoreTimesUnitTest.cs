using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class ZeroOrMoreTimesUnitTest
	{
		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.Character('a').ZeroOrMoreTimes();
			Assert.AreEqual("a*", predicate.ToString());
		}

		




	}
}
