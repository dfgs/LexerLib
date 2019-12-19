using System;
using System.Linq;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class ParseUnitTest
	{
		[TestMethod]
		public void ShouldCreateCharacterPredicate()
		{
			ICharacter predicate;

			predicate=Parse.Character('a');
			Assert.IsNotNull(predicate);
			Assert.AreEqual('a', predicate.Value);
		}

		[TestMethod]
		public void ShouldCreateSequencePredicate()
		{
			ISequence predicate;

			predicate = Parse.Characters('a', 'b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Parse.Characters("ab");
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
		}
		[TestMethod]
		public void ShouldCreateOrPredicate()
		{
			IOr predicate;

			predicate = Parse.Or('a', 'b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateAnyCharacterPredicate()
		{
			IAnyCharacter predicate;

			predicate = Parse.AnyCharacter();
			Assert.IsNotNull(predicate);
		}
		[TestMethod]
		public void ShouldCreateOneOrMoreTimesPredicate()
		{
			IOneOrMoreTimes predicate;

			predicate = Parse.OneOrMoreTimes('a');
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.OneOrMoreTimes(Parse.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Parse.OneOrMoreTimes(Parse.Character('a').ThenAnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));
		}
		[TestMethod]
		public void ShouldCreateZeroOrMoreTimesPredicate()
		{
			IZeroOrMoreTimes predicate;

			predicate = Parse.ZeroOrMoreTimes('a');
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.ZeroOrMoreTimes(Parse.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Parse.ZeroOrMoreTimes(Parse.Character('a').ThenAnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));
		}


		[TestMethod]
		public void ShouldCreatePerhapsPredicate()
		{
			IPerhaps predicate;

			predicate = Parse.Perhaps('a');
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.Perhaps(Parse.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Parse.Perhaps(Parse.Character('a').ThenAnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));
		}

	}
}
