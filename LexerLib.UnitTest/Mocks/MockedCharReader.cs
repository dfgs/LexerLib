using System;
using System.Collections.Generic;
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

		
		public char Peek()
		{
			return value[index];
		}

		public char Pop()
		{
			return value[index++];
		}

	}
}
