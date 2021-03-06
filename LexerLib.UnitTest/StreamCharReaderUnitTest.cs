﻿using System;
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
	public class StreamCharReaderUnitTest
	{
		[TestMethod]
		public void ShouldHaveValidConstructor()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new StreamCharReader(null,Encoding.Default)); ;
			Assert.ThrowsException<ArgumentNullException>(() => new StreamCharReader(new MemoryStream(), null)); ;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StreamCharReader(new MemoryStream(), Encoding.Default, -1)); ;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StreamCharReader(new MemoryStream(), Encoding.Default, 0)); ;
		}




		[TestMethod]
		public void ShouldReadCharactersWithLargeBuffer()
		{
			MemoryStream stream;
			ICharReader reader;

			stream = new MemoryStream(Encoding.ASCII.GetBytes("Welcome"));
			reader = new StreamCharReader(stream, Encoding.ASCII);
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
		public void ShouldReadCharactersWithSmallBuffer()
		{
			MemoryStream stream;
			ICharReader reader;

			stream = new MemoryStream(Encoding.ASCII.GetBytes("Welcome"));
			reader = new StreamCharReader(stream, Encoding.ASCII,1);
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
		public void ShouldReturnEOFWithLargeBuffer()
		{
			MemoryStream stream;
			ICharReader reader;

			stream = new MemoryStream(Encoding.ASCII.GetBytes("Welcome"));
			reader = new StreamCharReader(stream, Encoding.ASCII);
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
		public void ShouldReturnEOFWithSmallBuffer()
		{
			MemoryStream stream;
			ICharReader reader;

			stream = new MemoryStream(Encoding.ASCII.GetBytes("Welcome"));
			reader = new StreamCharReader(stream, Encoding.ASCII,1);
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
		public void ShouldReadAndSeekWithLargeBuffer()
		{
			MemoryStream stream;
			ICharReader reader;

			stream = new MemoryStream(Encoding.ASCII.GetBytes("Welcome"));
			reader = new StreamCharReader(stream, Encoding.ASCII);
			Assert.AreEqual('W', reader.Read());
			Assert.AreEqual('e', reader.Read());
			Assert.AreEqual('l', reader.Read());
			reader.Seek(0);
			Assert.AreEqual('W', reader.Read());
			Assert.AreEqual('e', reader.Read());
			Assert.AreEqual('l', reader.Read());
		}
		[TestMethod]
		public void ShouldReadAndSeekWithSmallBuffer()
		{
			MemoryStream stream;
			ICharReader reader;

			stream = new MemoryStream(Encoding.ASCII.GetBytes("Welcome"));
			reader = new StreamCharReader(stream, Encoding.ASCII,1);
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
