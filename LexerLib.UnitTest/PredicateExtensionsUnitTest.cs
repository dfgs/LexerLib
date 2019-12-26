using System;
using System.Linq;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class PredicateExtensionsUnitTest
	{

		#region Sequence generators
		[TestMethod]
		public void ShouldCreateSequencePredicateAddingCharacter()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenCharacter('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Parse.Characters("ab").ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateSequencePredicateAddingExceptCharacter()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenExceptCharacter('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ExceptCharacter));

			predicate = Parse.Characters("ab").ThenExceptCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ExceptCharacter));

		}
		[TestMethod]
		public void ShouldCreateSequencePredicateAddingCharacterRange()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenCharacterRange('b', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(CharacterRange));

			predicate = Parse.Characters("ab").ThenCharacterRange('c', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(CharacterRange));

		}
		[TestMethod]
		public void ShouldCreateSequencePredicateAddingExceptCharacterRange()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenExceptCharacterRange('b', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ExceptCharacterRange));

			predicate = Parse.Characters("ab").ThenExceptCharacterRange('c', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ExceptCharacterRange));

		}

		[TestMethod]
		public void ShouldCreateSequencePredicateAddingAnyCharacter()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Parse.Characters("ab").ThenAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(AnyCharacter));
		}

		[TestMethod]
		public void ShouldCreateSequencePredicateAddingAbstractPredicate()
		{
			ISequence predicate;

			predicate = Parse.Character('a').Then(Parse.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Parse.Character('a').Then('b'.OneOrMoreTimes());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
		}

		[TestMethod]
		public void ShouldCreateSequencePredicateAddingOneOrMoreTimes()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenOneOrMoreTimes('b').ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').ThenCharacter('c').ThenOneOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(OneOrMoreTimes));

			predicate = Parse.Character('a').ThenOneOrMoreTimes(Parse.AnyCharacter()).ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateSequencePredicateAddingZeroOrMoreTimes()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenZeroOrMoreTimes('b').ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').ThenCharacter('c').ThenZeroOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ZeroOrMoreTimes));

			predicate = Parse.Character('a').ThenZeroOrMoreTimes(Parse.AnyCharacter()).ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateSequencePredicateAddingPerhaps()
		{
			ISequence predicate;

			predicate = Parse.Character('a').ThenPerhaps('b').ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').ThenCharacter('c').ThenPerhaps('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Perhaps));

			predicate = Parse.Character('a').ThenPerhaps(Parse.AnyCharacter()).ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		#endregion

		#region Or generators
		[TestMethod]
		public void ShouldCreateOrPredicateAddingCharacter()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrCharacter('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Parse.Characters("ab").OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateOrPredicateAddingExceptCharacter()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrExceptCharacter('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ExceptCharacter));

			predicate = Parse.Characters("ab").OrExceptCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ExceptCharacter));

		}
		[TestMethod]
		public void ShouldCreateOrPredicateAddingCharacterRange()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrCharacterRange('b','z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(CharacterRange));

			predicate = Parse.Characters("ab").OrCharacterRange('c', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(CharacterRange));

		}
		[TestMethod]
		public void ShouldCreateOrPredicateAddingExceptCharacterRange()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrExceptCharacterRange('b', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ExceptCharacterRange));

			predicate = Parse.Characters("ab").OrExceptCharacterRange('c', 'z');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ExceptCharacterRange));

		}
		[TestMethod]
		public void ShouldCreateOrPredicateAddingAnyCharacter()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Parse.Characters("ab").OrAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));
		}

		[TestMethod]
		public void ShouldCreateOrPredicateAddingAbstractPredicate()
		{
			IOr predicate;

			predicate = Parse.Character('a').Or(Parse.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Parse.Character('a').Or('b'.OneOrMoreTimes());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
		}

		[TestMethod]
		public void ShouldCreateOrPredicateAddingOneOrMoreTimes()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrOneOrMoreTimes('b').OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').OrCharacter('c').OrOneOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(OneOrMoreTimes));

			predicate = Parse.Character('a').OrOneOrMoreTimes(Parse.AnyCharacter()).OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateOrPredicateAddingZeroOrMoreTimes()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrZeroOrMoreTimes('b').OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').OrCharacter('c').OrZeroOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ZeroOrMoreTimes));

			predicate = Parse.Character('a').OrZeroOrMoreTimes(Parse.AnyCharacter()).OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		[TestMethod]
		public void ShouldCreateOrPredicateAddingPerhaps()
		{
			IOr predicate;

			predicate = Parse.Character('a').OrPerhaps('b').OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').OrCharacter('c').OrPerhaps('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Perhaps));

			predicate = Parse.Character('a').OrPerhaps(Parse.AnyCharacter()).OrCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

		}
		#endregion




		[TestMethod]
		public void ShouldCreateOneOrMoreTimesPredicate()
		{
			IOneOrMoreTimes predicate;

			predicate = 'a'.OneOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.Character('a').OneOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.AnyCharacter().OneOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Parse.Character('a').ThenCharacter('b').OneOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));

		}
		[TestMethod]
		public void ShouldCreateZeroOrMoreTimesPredicate()
		{
			IZeroOrMoreTimes predicate;

			predicate = 'a'.ZeroOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.Character('a').ZeroOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.AnyCharacter().ZeroOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Parse.Character('a').ThenCharacter('b').ZeroOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));

		}
		[TestMethod]
		public void ShouldCreatePerhapsPredicate()
		{
			IPerhaps predicate;

			predicate = 'a'.Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.Character('a').Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Parse.AnyCharacter().Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Parse.Character('a').ThenCharacter('b').Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));

		}



	}
}
