using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public class TokenMatch
	{
		public bool Success
		{
			get;
			set;
		}
		public Token Token
		{
			get;
			set;
		}

		public Tag[] Tags
		{
			get;
			set;
		}

	}
}
