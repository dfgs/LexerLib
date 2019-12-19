using LexerLib.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Situations
{
	public interface ISituation
	{
		IEnumerable<ITransition> Transitions
		{
			get;
		}
	}
}
