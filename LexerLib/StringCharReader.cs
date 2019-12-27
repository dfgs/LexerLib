using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public class StringCharReader : ICharReader
	{

		private string value;
		public bool EOF => position==value.Length;

		private int position;
		public long Position => position;


		public StringCharReader(string Value)
		{
			if (Value== null) throw new ArgumentNullException("Value");
			this.value = Value;
		}

		

		public char Read()
		{
			if (EOF) throw new EndOfStreamException();
			return value[position++];
		}

		public void Seek(long Position)
		{
			this.position = (int)Position;
		}


	}
}
