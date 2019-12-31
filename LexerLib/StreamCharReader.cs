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
		private char[] buffer;

		
		private long bufferPosition;
		private int bufferSize;
		private int actualBufferSize;
		private int bufferIndex;

		// reader.BaseStream.Length is very long to get. It is recommanded to cache this value
		private long length;
		public bool EOF => Position==length;

		public long Position => bufferPosition+bufferIndex;


		public StreamCharReader(Stream Stream,Encoding Encoding,int BufferSize=65536)
		{
			if (Stream == null) throw new ArgumentNullException("Stream");
			if (Encoding == null) throw new ArgumentNullException("Encoding");
			if (BufferSize<=0) throw new ArgumentOutOfRangeException("BufferSize");
			this.reader = new BinaryReader(Stream,Encoding);
			this.length = reader.BaseStream.Length;
			this.bufferSize = BufferSize;
		}

		private void ReadBuffer()
		{
			bufferIndex = 0;
			bufferPosition = reader.BaseStream.Position;
			buffer = reader.ReadChars(bufferSize);
			actualBufferSize = buffer.Length;
		}

		public char Read()
		{
			char result;

			if (bufferIndex>=actualBufferSize) ReadBuffer();
			
			result = buffer[bufferIndex++];
			return result;
		}

		public void Seek(long Position)
		{
			if ((Position >= bufferPosition) && (Position <= bufferPosition + actualBufferSize))
			{
				bufferIndex = (int)(Position - bufferPosition);
			}
			else
			{
				reader.BaseStream.Seek(Position, SeekOrigin.Begin);
				ReadBuffer();
			}
		}

	}
}
