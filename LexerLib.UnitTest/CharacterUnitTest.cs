using System;
using System.Linq;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
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




	}
}
