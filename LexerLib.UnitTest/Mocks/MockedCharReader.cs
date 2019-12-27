using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.UnitTest.Mocks
{
	public class MockedCharReader:ICharReader
	{
		private string value;
		private int index;
		public long Position => index;
		public bool EOF => index == value.Length;


		public MockedCharReader(string Value)
		{
			this.value = Value;
		}

		
		

		public char Read()
		{
			if (index == value.Length) throw new EndOfStreamException();
			return value[index++];
		}

		public void Seek(long Position)
		{
			this.index = (int)Position;
		}
	}
}
