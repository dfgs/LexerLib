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

			predicate = Parse.Character('a').Or('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Parse.Characters("ab").Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

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

			predicate = Parse.Character('a').OrOneOrMoreTimes('b').Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').Or('c').OrOneOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(OneOrMoreTimes));

			predicate = Parse.Character('a').OrOneOrMoreTimes(Parse.AnyCharacter()).Or('c');
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

			predicate = Parse.Character('a').OrZeroOrMoreTimes('b').Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').Or('c').OrZeroOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ZeroOrMoreTimes));

			predicate = Parse.Character('a').OrZeroOrMoreTimes(Parse.AnyCharacter()).Or('c');
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

			predicate = Parse.Character('a').OrPerhaps('b').Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Parse.Character('a').Or('c').OrPerhaps('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Perhaps));

			predicate = Parse.Character('a').OrPerhaps(Parse.AnyCharacter()).Or('c');
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
