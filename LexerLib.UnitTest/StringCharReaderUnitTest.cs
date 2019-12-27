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
		public void ShouldReadCharacters()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual(0, reader.Position);
			Assert.AreEqual('W', reader.Read());
			Assert.AreEqual(1, reader.Position);
			Assert.AreEqual('e', reader.Read());
			Assert.AreEqual(2, reader.Position);
			Assert.AreEqual('l', reader.Read());
			Assert.AreEqual(3, reader.Position);
			Assert.AreEqual('c', reader.Read());
			Assert.AreEqual(4, reader.Position);
			Assert.AreEqual('o', reader.Read());
			Assert.AreEqual(5, reader.Position);
			Assert.AreEqual('m', reader.Read());
			Assert.AreEqual(6, reader.Position);
			Assert.AreEqual('e', reader.Read());
			Assert.AreEqual(7, reader.Position);
		}
		[TestMethod]
		public void ShouldReturnEOF()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('W', reader.Read());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('e', reader.Read());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('l', reader.Read());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('c', reader.Read());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('o', reader.Read());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('m', reader.Read());
			Assert.IsFalse(reader.EOF);
			Assert.AreEqual('e', reader.Read());
			Assert.IsTrue(reader.EOF);
		}
		[TestMethod]
		public void ShouldReadAndSeel()
		{
			ICharReader reader;

			reader = new StringCharReader("Welcome");
			Assert.AreEqual('W', reader.Read());
			Assert.AreEqual('e', reader.Read());
			Assert.AreEqual('l', reader.Read());
			reader.Seek(0);
			Assert.AreEqual('W', reader.Read());
			Assert.AreEqual('e', reader.Read());
			Assert.AreEqual('l', reader.Read());
		}



	}
}
