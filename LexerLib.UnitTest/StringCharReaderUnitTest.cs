using System;
using System.IO;
using System.Linq;
using System.Text;
using LexerLib.Exceptions;
using LexerLib.Predicates;
using LexerLib.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class StringCharReaderUnitTest
	{
		[TestMethod]
		public void ShouldHaveValidConstructor()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new StringCharReader(null)); ;
		}

		[TestMethod]
		public void ShouldPeekFirstCharacter()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual(0, reader.Position);
			Assert.AreEqual('W', reader.Peek());
			Assert.AreEqual(0, reader.Position);
			Assert.AreEqual('W', reader.Peek());
			Assert.AreEqual(0, reader.Position);
		}

		[TestMethod]
		public void ShouldPopFirstCharacter()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual(0, reader.Position);
			Assert.AreEqual('W', reader.Pop());
			Assert.AreEqual(1, reader.Position);
			Assert.AreEqual('e', reader.Peek());
			Assert.AreEqual(1, reader.Position);
		}

		[TestMethod]
		public void ShouldPopCharacters()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual(0, reader.Position);
			Assert.AreEqual('W', reader.Pop());
			Assert.AreEqual(1, reader.Position);
			Assert.AreEqual('e', reader.Pop());
			Assert.AreEqual(2, reader.Position);
			Assert.AreEqual('l', reader.Pop());
			Assert.AreEqual(3, reader.Position);
			Assert.AreEqual('c', reader.Pop());
			Assert.AreEqual(4, reader.Position);
			Assert.AreEqual('o', reader.Pop());
			Assert.AreEqual(5, reader.Position);
			Assert.AreEqual('m', reader.Pop());
			Assert.AreEqual(6, reader.Position);
			Assert.AreEqual('e', reader.Pop());
			Assert.AreEqual(7, reader.Position);
		}
		[TestMethod]
		public void ShouldReturnEOF()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('W', reader.Pop());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('e', reader.Pop());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('l', reader.Pop());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('c', reader.Pop());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('o', reader.Pop());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('m', reader.Pop());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('e', reader.Pop());
			Assert.IsTrue(reader.EOF);
		}
		[TestMethod]
		public void ShouldPeekAndPop()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual('W', reader.Peek());
			Assert.AreEqual('W', reader.Pop());
			Assert.AreEqual('e', reader.Peek());
			Assert.AreEqual('e', reader.Pop());
			Assert.AreEqual('l', reader.Peek());
			Assert.AreEqual('l', reader.Pop());
			Assert.AreEqual('c', reader.Peek());
			Assert.AreEqual('c', reader.Pop());
			Assert.AreEqual('o', reader.Peek());
			Assert.AreEqual('o', reader.Pop());
			Assert.AreEqual('m', reader.Peek());
			Assert.AreEqual('m', reader.Pop());
			Assert.AreEqual('e', reader.Peek());
			Assert.AreEqual('e', reader.Pop());
		}

		[TestMethod]
		public void ShouldNotPopCharacterAtEOF()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual('W', reader.Pop());
			Assert.AreEqual('e', reader.Pop());
			Assert.AreEqual('l', reader.Pop());
			Assert.AreEqual('c', reader.Pop());
			Assert.AreEqual('o', reader.Pop());
			Assert.AreEqual('m', reader.Pop());
			Assert.AreEqual('e', reader.Pop());
			Assert.ThrowsException<System.IO.EndOfStreamException>(() => reader.Pop());
		}
		[TestMethod]
		public void ShouldNotPeekCharacterAtEOF()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual('W', reader.Pop());
			Assert.AreEqual('e', reader.Pop());
			Assert.AreEqual('l', reader.Pop());
			Assert.AreEqual('c', reader.Pop());
			Assert.AreEqual('o', reader.Pop());
			Assert.AreEqual('m', reader.Pop());
			Assert.AreEqual('e', reader.Pop());
			Assert.ThrowsException<System.IO.EndOfStreamException>(() => reader.Peek());
		}


	}
}
