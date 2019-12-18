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

			predicate=Predicate.Character('a');
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
		public void ShouldCreateOrPredicate()
		{
			IOr predicate;

			predicate = Predicate.Or('a', 'b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateAnyCharacterPredicate()
		{
			IAnyCharacter predicate;

			predicate = Predicate.AnyCharacter();
			Assert.IsNotNull(predicate);
		}
		[TestMethod]
		public void ShouldCreateOneOrMoreTimesPredicate()
		{
			IOneOrMoreTimes predicate;

			predicate = Predicate.OneOrMoreTimes('a');
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Predicate.OneOrMoreTimes(Predicate.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Predicate.OneOrMoreTimes(Predicate.Character('a').ThenAnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));
		}
		[TestMethod]
		public void ShouldCreateZeroOrMoreTimesPredicate()
		{
			IZeroOrMoreTimes predicate;

			predicate = Predicate.ZeroOrMoreTimes('a');
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Predicate.ZeroOrMoreTimes(Predicate.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Predicate.ZeroOrMoreTimes(Predicate.Character('a').ThenAnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));
		}


		[TestMethod]
		public void ShouldCreatePerhapsPredicate()
		{
			IPerhaps predicate;

			predicate = Predicate.Perhaps('a');
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Predicate.Perhaps(Predicate.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Predicate.Perhaps(Predicate.Character('a').ThenAnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));
		}

	}
}
