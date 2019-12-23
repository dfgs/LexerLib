using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Exceptions
{
	public class InvalidInputException:LexerException
	{
		
		public char Input
		{
			get;
			private set;
		}

		public InvalidInputException(long Position,char Input):base(Position)
		{
			this.Input = Input;
		}
	}
}
