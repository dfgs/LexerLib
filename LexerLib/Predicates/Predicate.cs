using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public abstract class Predicate:IPredicate
	{
		public static Character Parse(char Value)
		{
			return new Character(Value);
		}
		public static Sequence Parse(params char[] Items)
		{
			return new Sequence(Items.Select(item=>new Character(item)).ToArray());
		}
		public static Sequence Parse(string Items)
		{
			return new Sequence(Items.Select(item=>new Character(item)).ToArray() );
		}
		public static AnyCharacter ParseAny()
		{
			return new AnyCharacter();
		}

		

	}
}
