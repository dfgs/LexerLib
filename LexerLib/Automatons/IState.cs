using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Automatons
{
	public interface IState
	{
		void CreateShift(char Input, int NextStateIndex);
		int? GetNextStateIndex(char Input);
	}
}
