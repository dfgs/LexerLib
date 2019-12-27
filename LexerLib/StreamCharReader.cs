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
		
		public bool EOF => reader.BaseStream.Position==reader.BaseStream.Length;

		public long Position => reader.BaseStream.Position;


		public StreamCharReader(Stream Stream,Encoding Encoding)
		{
			if (Stream == null) throw new ArgumentNullException("Stream");
			if (Encoding == null) throw new ArgumentNullException("Encoding");
			this.reader = new BinaryReader(Stream,Encoding);
		}


		public char Read()
		{
			return reader.ReadChar();
		}

		public void Seek(long Position)
		{
			reader.BaseStream.Seek(Position,SeekOrigin.Begin);
		}

	}
}
