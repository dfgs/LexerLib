using System;
using System.Linq;
using LexerLib.Automatons;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest.Predicates
{
	[TestClass]
	public class AnyCharacterUnitTest
	{
		[TestMethod]
		public void ShouldConvertToString()
		{
			IPredicate predicate;

			predicate = Parse.AnyCharacter();
			Assert.AreEqual(".", predicate.ToString());
		}

		[TestMethod]
		public void ShouldAccept()
		{
			AnyCharacter predicate ;

			predicate = Parse.AnyCharacter();
			Assert.IsTrue(predicate.Accept('a'));
			Assert.IsTrue(predicate.Accept('b'));
			Assert.IsTrue(predicate.Accept('c'));
		}




	}
}
