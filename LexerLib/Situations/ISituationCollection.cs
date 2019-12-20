using LexerLib.Automatons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public interface ISituationCollection
	{
		IEnumerable<ISituation> Items
		{
			get;
		}
		IState State
		{
			get;
		}
	}
}
