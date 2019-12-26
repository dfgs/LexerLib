using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class CharacterRangeRangeUnitTest
	{
		

		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.CharacterRange('a','z');
			Assert.AreEqual("[a-z]", predicate.ToString());
		}

		[TestMethod]
		public void ShouldAccept()
		{
			CharacterRange predicate ;

			predicate = Parse.CharacterRange('a', 'z');
			Assert.IsTrue(predicate.Accept('a'));
			Assert.IsTrue(predicate.Accept('b'));
			Assert.IsTrue(predicate.Accept('c'));
			Assert.IsTrue(predicate.Accept('z'));
		}

		[TestMethod]
		public void ShouldNotAccept()
		{
			CharacterRange predicate;

			predicate = Parse.CharacterRange('a', 'z');
			Assert.IsFalse(predicate.Accept('1'));
		}


	}
}
