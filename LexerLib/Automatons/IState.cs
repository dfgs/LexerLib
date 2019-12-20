using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Automatons
{
	public interface IState
	{
		IEnumerable<string> Reductions
		{
			get;
		}

		void CreateShift(char Input, int NextStateIndex);
		void CreateReduction(string Reduction);
		int? GetNextStateIndex(char Input);
	}
}
