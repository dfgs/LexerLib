using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public interface ICharReader
	{
		bool EOF
		{
			get;
		}
		long Position
		{
			get;
		}
		char Peek();
		char Pop();
	}
}
