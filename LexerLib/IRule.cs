using LexerLib.Predicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib
{
	public interface IRule
	{
		string Name
		{
			get;
			set;
		}
		IPredicate Predicate
		{
			get;
		}
	}
}
