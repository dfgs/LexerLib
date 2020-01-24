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

		private List<IRule> reductions;
		public IEnumerable<IRule> Reductions
		{
			get => reductions;
		}


		public State()
		{
			indices = new int?[65535];
			reductions = new List<IRule>();
		}


		public void CreateShift(char Input, int NextStateIndex)
		{
			indices[Input] = NextStateIndex;
		}
		public void CreateReduction(IRule Rule)
		{
			reductions.Add(Rule);
		}

		public int? GetNextStateIndex(char Input)
		{
			return indices[Input];
		}

		public IEnumerable<string> DumpValidShifts()
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
