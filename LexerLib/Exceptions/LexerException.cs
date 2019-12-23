using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Exceptions
{
	public abstract class LexerException:Exception
	{
		public long Position
		{
			get;
			private set;
		}
		

		public LexerException(long Position)
		{
			this.Position = Position;
		}
	}
}
