using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class ExceptCharacterUnitTest
	{
		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.ExceptCharacter('a');
			Assert.AreEqual("!a", predicate.ToString());
		}

		[TestMethod]
		public void ShouldAccept()
		{
			ExceptCharacter predicate ;

			predicate = Parse.ExceptCharacter('a');
			Assert.IsTrue(predicate.Accept('b'));
		}

		[TestMethod]
		public void ShouldNotAccept()
		{
			ExceptCharacter predicate;

			predicate = Parse.ExceptCharacter('a');
			Assert.IsFalse(predicate.Accept('a'));
		}


	}
}
