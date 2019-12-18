using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public static class PredicateExtensions
	{
		public static Sequence Parse(this Sequence Sequence, char Value)
		{
			Sequence.Items.Add(new Character(Value));
			return Sequence;
		}
		public static Sequence Parse(this Predicate Predicate, char Value)
		{
			return new Sequence(Predicate, new Character(Value));
		}

		public static Sequence ParseAny(this Sequence Sequence)
		{
			Sequence.Items.Add(new AnyCharacter());
			return Sequence;
		}
		public static Sequence ParseAny(this Predicate Predicate)
		{
			return new Sequence(Predicate, new AnyCharacter());
		}



	}
}
