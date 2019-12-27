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

		public static bool operator ==(Token A, Token B)
		{
			return (A.Class==B.Class) && (A.Value==B.Value);
		}
		public static bool operator !=(Token A, Token B)
		{
			return (A.Class != B.Class) || (A.Value != B.Value);
		}

		public override bool Equals(object obj)
		{
			if (obj is Token other)
			{
				return (this.Class == other.Class) && (this.Value == other.Value);
			}
			return false;
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hash = 17;
				hash = hash * 23 + Class?.GetHashCode()??1;
				hash = hash * 23 + Value?.GetHashCode()??3;
				return hash;
			}
		}


	}
}
