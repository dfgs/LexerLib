using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public interface ILexer
	{
		Token Read(ICharReader Reader);
		bool TryRead(ICharReader Reader,out Token Token);
	}
}
