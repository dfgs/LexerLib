using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class CharacterUnitTest
	{
		[TestMethod]
		public void ShouldImplicitConvertFromChar()
		{
			Character predicate;

			predicate = 'a';
			Assert.IsNotNull(predicate);
			Assert.AreEqual('a', predicate.Value);
		}

		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.Character('a');
			Assert.AreEqual("a", predicate.ToString());
		}

		[TestMethod]
		public void ShouldAccept()
		{
			Character predicate ;

			predicate = Parse.Character('a');
			Assert.IsTrue(predicate.Accept('a'));
		}

		[TestMethod]
		public void ShouldNotAccept()
		{
			Character predicate;

			predicate = Parse.Character('a');
			Assert.IsFalse(predicate.Accept('b'));
		}


	}
}
