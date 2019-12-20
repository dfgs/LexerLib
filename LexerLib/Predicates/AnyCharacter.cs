using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class AnyCharacter : ShiftPredicate, IAnyCharacter
	{
	

		public AnyCharacter()
		{

		}

		public override bool Accept(char Input)
		{
			return true;
		}

		public override string ToString()
		{
			return ".";
		}


	}
}
