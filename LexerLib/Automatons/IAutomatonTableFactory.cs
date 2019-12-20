using LexerLib.Situations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Automatons
{
	public interface IAutomatonTableFactory
	{
		IState[] BuildStates(ISituation RootSituation);
	}
}
