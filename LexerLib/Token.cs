using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public struct Token
	{
		public string Class
		{
			get;
			private set;
		}
		public string Value
		{
			get;
			private set;
		}

		public Token(string Class,string Value)
		{
			this.Class = Class;this.Value = Value;
		}

		public override string ToString()
		{
			return $"<{Class},{Value}>";
		}
	}
}
