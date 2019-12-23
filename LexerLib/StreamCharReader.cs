using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public class StreamCharReader : ICharReader
	{
		private BinaryReader reader;
		private bool eof;
		public bool EOF => eof;

		private long position;
		public long Position => position;

		private char currentValue;

		public StreamCharReader(Stream Stream,Encoding Encoding)
		{
			if (Stream == null) throw new ArgumentNullException("Stream");
			if (Encoding == null) throw new ArgumentNullException("Encoding");
			this.reader = new BinaryReader(Stream,Encoding);
			ReadCurrentValue();
		}

		private void ReadCurrentValue()
		{
			position = reader.BaseStream.Position;
			eof= reader.BaseStream.Position == reader.BaseStream.Length;
			if (!eof) currentValue = reader.ReadChar();
		}
		public char Peek()
		{
			if (EOF) throw new EndOfStreamException();
			return currentValue;
		}

		public char Pop()
		{
			char result;

			if (EOF) throw new EndOfStreamException();
			result = currentValue;
			ReadCurrentValue();
			return result;
		}

	}
}
