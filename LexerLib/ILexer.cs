using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public interface ILexer
	{
		TokenMatch Read(ICharReader Reader);
		TokenMatch TryRead(ICharReader Reader);
	}
}
