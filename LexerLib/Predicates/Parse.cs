using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public static class Parse
	{
		public static Character Character(char Value)
		{
			return new Character(Value);
		}
		public static Sequence Characters(params char[] Items)
		{
			return new Sequence(Items.Select(item => new Character(item)).ToArray());
		}
		public static Sequence Characters(string Items)
		{
			return new Sequence(Items.Select(item => new Character(item)).ToArray());
		}
		public static Or Or(params char[] Items)
		{
			return new Or(Items.Select(item => new Character(item)).ToArray());
		}

		public static AnyCharacter AnyCharacter()
		{
			return new AnyCharacter();
		}

		public static OneOrMoreTimes OneOrMoreTimes(char Item)
		{
			return new OneOrMoreTimes(new Character(Item));
		}
		public static OneOrMoreTimes OneOrMoreTimes(Predicate Item)
		{
			return new OneOrMoreTimes(Item);
		}

		public static ZeroOrMoreTimes ZeroOrMoreTimes(char Item)
		{
			return new ZeroOrMoreTimes(new Character(Item));
		}
		public static ZeroOrMoreTimes ZeroOrMoreTimes(Predicate Item)
		{
			return new ZeroOrMoreTimes(Item);
		}

		public static Perhaps Perhaps(char Item)
		{
			return new Perhaps(new Character(Item));
		}
		public static Perhaps Perhaps(Predicate Item)
		{
			return new Perhaps(Item);
		}
	}
}
