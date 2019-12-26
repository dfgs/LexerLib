using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class ExceptCharacterRangeRangeUnitTest
	{
		

		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.ExceptCharacterRange('a','z');
			Assert.AreEqual("![a-z]", predicate.ToString());
		}

		[TestMethod]
		public void ShouldAccept()
		{
			ExceptCharacterRange predicate ;

			predicate = Parse.ExceptCharacterRange('a', 'z');
			Assert.IsFalse(predicate.Accept('a'));
			Assert.IsFalse(predicate.Accept('b'));
			Assert.IsFalse(predicate.Accept('c'));
			Assert.IsFalse(predicate.Accept('z'));
		}

		[TestMethod]
		public void ShouldNotAccept()
		{
			ExceptCharacterRange predicate;

			predicate = Parse.ExceptCharacterRange('a', 'z');
			Assert.IsTrue(predicate.Accept('1'));
		}


	}
}
