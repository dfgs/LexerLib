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
			Assert.ThrowsException<ArgumentNullException>(() => new Lexer(null, new Rule())); ;
			Assert.ThrowsException<ArgumentNullException>(() => new Lexer(new MockedCharReader("abc"), null)); ;
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

			lexer = new Lexer(reader, word, number);

			token = lexer.Read();
			Assert.AreEqual("Number", token.Class);
			Assert.AreEqual("12345", token.Value);

			token = lexer.Read();
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

			lexer = new Lexer(reader, word, number);

			result= lexer.TryRead(out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Number", token.Class);
			Assert.AreEqual("12345", token.Value);

			result = lexer.TryRead(out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("abc", token.Value);

			
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
			lexer = new Lexer(reader, word);

			token = lexer.Read();
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toke");
			lexer = new Lexer(reader, word);

			Assert.ThrowsException<EndOfStreamException>( ()=>lexer.Read() );
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
			lexer = new Lexer(reader, word);

			token = lexer.Read();
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toked");
			lexer = new Lexer(reader, word);

			ex=Assert.ThrowsException<InvalidInputException>(() => lexer.Read());
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
			lexer = new Lexer(reader, word);

			result = lexer.TryRead(out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toke");
			lexer = new Lexer(reader, word);
			
			result = lexer.TryRead(out token);
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
			lexer = new Lexer(reader, word);

			result = lexer.TryRead(out token);
			Assert.IsTrue(result);
			Assert.AreEqual("Word", token.Class);
			Assert.AreEqual("token", token.Value);

			reader = new MockedCharReader("toked");
			lexer = new Lexer(reader, word);

			result = lexer.TryRead(out token);
			Assert.IsFalse(result);
			Assert.IsNull(token.Class);
			Assert.AreEqual("toke", token.Value);

		}



	}
}
