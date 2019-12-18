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

			predicate = Predicate.Character('a').ThenCharacter('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Predicate.Parse("ab").ThenCharacter('c');
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

			predicate = Predicate.Character('a').ThenAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Predicate.Parse("ab").ThenAnyCharacter();
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

			predicate = Predicate.Character('a').Then(Predicate.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Predicate.Character('a').Then('b'.OneOrMoreTimes());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
		}

		[TestMethod]
		public void ShouldCreateSequencePredicateAddingOneOrMoreTimes()
		{
			ISequence predicate;

			predicate = Predicate.Character('a').ThenOneOrMoreTimes('b').ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Predicate.Character('a').ThenCharacter('c').ThenOneOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(OneOrMoreTimes));

			predicate = Predicate.Character('a').ThenOneOrMoreTimes(Predicate.AnyCharacter()).ThenCharacter('c');
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

			predicate = Predicate.Character('a').ThenZeroOrMoreTimes('b').ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Predicate.Character('a').ThenCharacter('c').ThenZeroOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ZeroOrMoreTimes));

			predicate = Predicate.Character('a').ThenZeroOrMoreTimes(Predicate.AnyCharacter()).ThenCharacter('c');
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

			predicate = Predicate.Character('a').ThenPerhaps('b').ThenCharacter('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Predicate.Character('a').ThenCharacter('c').ThenPerhaps('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Perhaps));

			predicate = Predicate.Character('a').ThenPerhaps(Predicate.AnyCharacter()).ThenCharacter('c');
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

			predicate = Predicate.Character('a').Or('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

			predicate = Predicate.Parse("ab").Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));

		}

		[TestMethod]
		public void ShouldCreateOrPredicateAddingAnyCharacter()
		{
			IOr predicate;

			predicate = Predicate.Character('a').OrAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Predicate.Parse("ab").OrAnyCharacter();
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Sequence));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
		}

		[TestMethod]
		public void ShouldCreateOrPredicateAddingAbstractPredicate()
		{
			IOr predicate;

			predicate = Predicate.Character('a').Or(Predicate.AnyCharacter());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(AnyCharacter));

			predicate = Predicate.Character('a').Or('b'.OneOrMoreTimes());
			Assert.IsNotNull(predicate);
			Assert.AreEqual(2, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
		}

		[TestMethod]
		public void ShouldCreateOrPredicateAddingOneOrMoreTimes()
		{
			IOr predicate;

			predicate = Predicate.Character('a').OrOneOrMoreTimes('b').Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(OneOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Predicate.Character('a').Or('c').OrOneOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(OneOrMoreTimes));

			predicate = Predicate.Character('a').OrOneOrMoreTimes(Predicate.AnyCharacter()).Or('c');
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

			predicate = Predicate.Character('a').OrZeroOrMoreTimes('b').Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(ZeroOrMoreTimes));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Predicate.Character('a').Or('c').OrZeroOrMoreTimes('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(ZeroOrMoreTimes));

			predicate = Predicate.Character('a').OrZeroOrMoreTimes(Predicate.AnyCharacter()).Or('c');
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

			predicate = Predicate.Character('a').OrPerhaps('b').Or('c');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Perhaps));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Character));

			predicate = Predicate.Character('a').Or('c').OrPerhaps('b');
			Assert.IsNotNull(predicate);
			Assert.AreEqual(3, predicate.Items.Count());
			Assert.IsInstanceOfType(predicate.Items.ElementAt(0), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(1), typeof(Character));
			Assert.IsInstanceOfType(predicate.Items.ElementAt(2), typeof(Perhaps));

			predicate = Predicate.Character('a').OrPerhaps(Predicate.AnyCharacter()).Or('c');
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

			predicate = Predicate.Character('a').OneOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Predicate.AnyCharacter().OneOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Predicate.Character('a').ThenCharacter('b').OneOrMoreTimes();
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

			predicate = Predicate.Character('a').ZeroOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Predicate.AnyCharacter().ZeroOrMoreTimes();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Predicate.Character('a').ThenCharacter('b').ZeroOrMoreTimes();
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

			predicate = Predicate.Character('a').Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Character));

			predicate = Predicate.AnyCharacter().Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(AnyCharacter));

			predicate = Predicate.Character('a').ThenCharacter('b').Perhaps();
			Assert.IsNotNull(predicate);
			Assert.IsNotNull(predicate.Item);
			Assert.IsInstanceOfType(predicate.Item, typeof(Sequence));

		}



	}
}
