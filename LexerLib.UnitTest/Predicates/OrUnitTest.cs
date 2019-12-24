using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class OrUnitTest
	{
		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d');
			Assert.AreEqual("(a|b|c|d)", predicate.ToString());
		}

		




	}
}
