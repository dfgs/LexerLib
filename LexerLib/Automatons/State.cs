using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Automatons
{
	public class State : IState
	{
		private int?[] indices;

		public State()
		{
			indices = new int?[65535];
		}

		public void CreateShift(char Input, int NextStateIndex)
		{
			indices[Input] = NextStateIndex;
		}

		public int? GetNextStateIndex(char Input)
		{
			return indices[Input];
		}

		public IEnumerable<string> GetValidShifts()
		{
			int? index;
			for(char c=char.MinValue;c<char.MaxValue;c++)
			{
				index = indices[c];
				if (index == null) continue;
				yield return $"{c}->{index.Value}";
			}
		}

	}
}
