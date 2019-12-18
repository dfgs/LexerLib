using System;
using System.Linq;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class PredicateExtensionsUnitTest
	{
		

		[TestMethod]
		public void ShouldCreateSequencePredicateAddingCharacter()
		{
			ISequence predicate;

			predicate = Predicate.Parse('a').Parse('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Predicate.Parse("ab").Parse('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}

		[TestMethod]
		public void ShouldCreateSequencePredicateAddingAnyCharacter()
		{
			ISequence predicate;

			predicate = Predicate.Parse('a').ParseAny();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Predicate.Parse("ab").ParseAny();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(AnyCharacter));
		}


	}
}
