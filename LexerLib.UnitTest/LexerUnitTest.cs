using System;
using System.Linq;
using LexerLib.Exceptions;
using LexerLib.Predicates;
using LexerLib.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class LexerUnitTest
	{
		[TestMethod]
		public void ShouldHaveValidConstructor()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Lexer(null)); ;
		}

		[TestMethod]
		public void ShouldRead()
		{
			ICharReader reader;
			ILexer lexer;
			Rule number, word;
			TokenMatch tokenMatch;

			reader = new MockedCharReader("12345abc");

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer( word, number);

			tokenMatch = lexer.Read(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Number", tokenMatch.Token.Class);
			Assert.AreEqual("12345", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(0, tokenMatch.Tags.Length);

			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("abc", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(0, tokenMatch.Tags.Length);
		}

		[TestMethod]
		public void ShouldTryRead()
		{
			ICharReader reader;
			ILexer lexer;
			Rule number, word;
			TokenMatch tokenMatch;

			reader = new MockedCharReader("12345abc");

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer( word, number);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Number", tokenMatch.Token.Class);
			Assert.AreEqual("12345", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(0, tokenMatch.Tags.Length);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("abc", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(0, tokenMatch.Tags.Length);


		}

		[TestMethod]
		public void ShouldReadWithTags()
		{
			ICharReader reader;
			ILexer lexer;
			Rule number, word;
			TokenMatch tokenMatch;

			reader = new MockedCharReader("12345abc");

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			number.Tags.Add(new Tag("Number","Value"));
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());
			word.Tags.Add(new Tag("Word", "Value"));

			lexer = new Lexer(word, number);

			tokenMatch = lexer.Read(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Number", tokenMatch.Token.Class);
			Assert.AreEqual("12345", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(1, tokenMatch.Tags.Length);
			Assert.AreEqual("Number", tokenMatch.Tags[0].Name);

			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("abc", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(1, tokenMatch.Tags.Length);
			Assert.AreEqual("Word", tokenMatch.Tags[0].Name);

		}

		[TestMethod]
		public void ShouldTryReadWithTags()
		{
			ICharReader reader;
			ILexer lexer;
			Rule number, word;
			TokenMatch tokenMatch;

			reader = new MockedCharReader("12345abc");

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			number.Tags.Add(new Tag("Number", "Value"));
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());
			word.Tags.Add(new Tag("Word", "Value"));

			lexer = new Lexer(word, number);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Number", tokenMatch.Token.Class);
			Assert.AreEqual("12345", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(1, tokenMatch.Tags.Length);
			Assert.AreEqual("Number", tokenMatch.Tags[0].Name);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("abc", tokenMatch.Token.Value);
			Assert.IsNotNull(tokenMatch.Tags);
			Assert.AreEqual(1, tokenMatch.Tags.Length);
			Assert.AreEqual("Word", tokenMatch.Tags[0].Name);


		}


		[TestMethod]
		public void ShouldNotRead()
		{
			ILexer lexer;
			Rule number, word;


			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer(word, number);

			Assert.ThrowsException<ArgumentNullException>(()=> lexer.Read(null));
		}

		[TestMethod]
		public void ShouldNotTryRead()
		{
			ILexer lexer;
			Rule number, word;
			TokenMatch tokenMatch;

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer(word, number);
			Assert.ThrowsException<ArgumentNullException>(() => tokenMatch=lexer.TryRead(null));

		}

		[TestMethod]
		public void ShouldFailToReadAndThrowEndOfStreamException()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			TokenMatch tokenMatch;


			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer( word);

			tokenMatch = lexer.Read(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("token", tokenMatch.Token.Value);

			reader = new MockedCharReader("toke");
			lexer = new Lexer(word);

			Assert.ThrowsException<EndOfStreamException>( ()=> tokenMatch=lexer.Read(reader) );
		}
		[TestMethod]
		public void ShouldFailToReadAndThrowInvalidInputException()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			TokenMatch tokenMatch;
			InvalidInputException ex;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer( word);

			tokenMatch = lexer.Read(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("token", tokenMatch.Token.Value);

			reader = new MockedCharReader("toked");
			lexer = new Lexer( word);

			ex=Assert.ThrowsException<InvalidInputException>(() => tokenMatch=lexer.Read(reader));
			Assert.AreEqual('d', ex.Input);
		}
		[TestMethod]
		public void ShouldFailToTryReadWhenEOF()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			TokenMatch tokenMatch;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer( word);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("token", tokenMatch.Token.Value);

			reader = new MockedCharReader("toke");
			lexer = new Lexer( word);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsFalse(tokenMatch.Success);
			Assert.IsNull(tokenMatch.Token.Class);
			Assert.AreEqual("toke", tokenMatch.Token.Value);

		}
		[TestMethod]
		public void ShouldFailToTryReadWhenInvalidChar()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			TokenMatch tokenMatch;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer(word);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("token", tokenMatch.Token.Value);

			reader = new MockedCharReader("toked");
			lexer = new Lexer(word);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsFalse(tokenMatch.Success);
			Assert.IsNull(tokenMatch.Token.Class);
			Assert.AreEqual("toked", tokenMatch.Token.Value);

		}
		[TestMethod]
		public void ShouldFailToTryReadWhenInvalidCharAtFirstPosition()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			TokenMatch tokenMatch;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer(word);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsTrue(tokenMatch.Success);
			Assert.AreEqual("Word", tokenMatch.Token.Class);
			Assert.AreEqual("token", tokenMatch.Token.Value);

			reader = new MockedCharReader(",oken");
			lexer = new Lexer(word);

			tokenMatch = lexer.TryRead(reader);
			Assert.IsFalse(tokenMatch.Success);
			Assert.IsNull(tokenMatch.Token.Class);
			Assert.AreEqual(",", tokenMatch.Token.Value);

		}
		[TestMethod]
		public void ShouldReadAndSeek()
		{
			ICharReader reader;
			ILexer lexer;
			Rule letter, word;
			TokenMatch tokenMatch;

			reader = new MockedCharReader("abcde");

			word = new Rule("Word", Parse.Characters("abcdef"));
			letter = new Rule("Letter", Parse.CharacterRange('a','z'));

			lexer = new Lexer(word, letter);

			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Letter", tokenMatch.Token.Class);
			Assert.AreEqual("a", tokenMatch.Token.Value);
			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Letter", tokenMatch.Token.Class);
			Assert.AreEqual("b", tokenMatch.Token.Value);
			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Letter", tokenMatch.Token.Class);
			Assert.AreEqual("c", tokenMatch.Token.Value);
			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Letter", tokenMatch.Token.Class);
			Assert.AreEqual("d", tokenMatch.Token.Value);
			tokenMatch = lexer.Read(reader);
			Assert.AreEqual("Letter", tokenMatch.Token.Class);
			Assert.AreEqual("e", tokenMatch.Token.Value);
			


		}


	}
}
