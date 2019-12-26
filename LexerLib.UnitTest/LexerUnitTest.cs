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
			Token token;

			reader = new MockedCharReader("12345abc");

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer( word, number);

			token = lexer.Read(reader);
			Assert.AreEqual("Number", token.Class);
			Assert.AreEqual("12345", token.Value);

			token = lexer.Read(reader);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("abc", token.Value);
		}

		[TestMethod]
		public void ShouldTryRead()
		{
			ICharReader reader;
			ILexer lexer;
			Rule number, word;
			Token token;
			bool result;

			reader = new MockedCharReader("12345abc");

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer( word, number);

			result= lexer.TryRead(reader, out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Number", token.Class);
			Assert.AreEqual("12345", token.Value);

			result = lexer.TryRead(reader, out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("abc", token.Value);

			
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
			Token token;

			number = new Rule("Number", Parse.Character('0').OrCharacter('1').OrCharacter('2').OrCharacter('3').OrCharacter('4').OrCharacter('5').OrCharacter('6').OrCharacter('7').OrCharacter('8').OrCharacter('9').OneOrMoreTimes());
			word = new Rule("Word", Parse.Character('a').OrCharacter('b').OrCharacter('c').OrCharacter('d').OneOrMoreTimes());

			lexer = new Lexer(word, number);
			Assert.ThrowsException<ArgumentNullException>(() => lexer.TryRead(null,out token));

		}

		[TestMethod]
		public void ShouldFailToReadAndThrowEndOfStreamException()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			Token token;


			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer( word);

			token = lexer.Read(reader);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toke");
			lexer = new Lexer(word);

			Assert.ThrowsException<EndOfStreamException>( ()=>lexer.Read(reader) );
		}
		[TestMethod]
		public void ShouldFailToReadAndThrowInvalidInputException()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			Token token;
			InvalidInputException ex;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer( word);

			token = lexer.Read(reader);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toked");
			lexer = new Lexer( word);

			ex=Assert.ThrowsException<InvalidInputException>(() => lexer.Read(reader));
			Assert.AreEqual('d', ex.Input);
		}
		[TestMethod]
		public void ShouldFailToTryReadWhenEOF()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			Token token;
			bool result;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer( word);

			result = lexer.TryRead(reader,out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toke");
			lexer = new Lexer( word);
			
			result = lexer.TryRead(reader,out token);
			Assert.IsFalse(result);
			Assert.IsNull(token.Class);
			Assert.AreEqual("toke", token.Value);

		}
		[TestMethod]
		public void ShouldFailToTryReadWhenInvalidChar()
		{
			ICharReader reader;
			ILexer lexer;
			Rule word;
			Token token;
			bool result;

			word = new Rule("Word", Parse.Characters("token"));

			reader = new MockedCharReader("token");
			lexer = new Lexer(word);

			result = lexer.TryRead(reader,out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toked");
			lexer = new Lexer(word);

			result = lexer.TryRead(reader,out token);
			Assert.IsFalse(result);
			Assert.IsNull(token.Class);
			Assert.AreEqual("toke", token.Value);

		}



	}
}
