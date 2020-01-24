using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Automatons
{
	public interface IState
	{
		IEnumerable<IRule> Reductions
		{
			get;
		}

		void CreateShift(char Input, int NextStateIndex);
		void CreateReduction(IRule Rule);
		int? GetNextStateIndex(char Input);
	}
}
