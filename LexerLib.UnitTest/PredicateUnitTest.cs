using System;
using System.Linq;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class PredicateUnitTest
	{
		[TestMethod]
		public void ShouldCreateCharacterPredicate()
		{
			ICharacter predicate;

			predicate=Predicate.Parse('a');
			Assert.IsNotNull(predicate);
			Assert.AreEqual('a', predicate.Value);
		}

		[TestMethod]
		public void ShouldCreateSequencePredicate()
		{
			ISequence predicate;

			predicate = Predicate.Parse('a', 'b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Predicate.Parse("ab");
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
		}

		[TestMethod]
		public void ShouldCreateAnyCharacterPredicate()
		{
			IAnyCharacter predicate;

			predicate = Predicate.ParseAny();
			Assert.IsNotNull(predicate);
		}



	}
}
