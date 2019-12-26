using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public static class PredicateExtensions
	{
		#region Sequence generators
		public static Sequence ThenCharacter(this Sequence Sequence, char Value)
		{
			Sequence.Items.Add(new Character(Value));
			return Sequence;
		}
		public static Sequence ThenCharacter(this Predicate Predicate, char Value)
		{
			return new Sequence(Predicate, new Character(Value));
		}
		public static Sequence ThenExceptCharacter(this Sequence Sequence, char Value)
		{
			Sequence.Items.Add(new ExceptCharacter(Value));
			return Sequence;
		}
		public static Sequence ThenExceptCharacter(this Predicate Predicate, char Value)
		{
			return new Sequence(Predicate, new ExceptCharacter(Value));
		}
		public static Sequence ThenCharacterRange(this Sequence Sequence, char FirstValue, char LastValue)
		{
			Sequence.Items.Add(new CharacterRange(FirstValue, LastValue));
			return Sequence;
		}
		public static Sequence ThenCharacterRange(this Predicate Predicate, char FirstValue, char LastValue)
		{
			return new Sequence(Predicate, new CharacterRange(FirstValue, LastValue));
		}
		public static Sequence ThenExceptCharacterRange(this Sequence Sequence, char FirstValue, char LastValue)
		{
			Sequence.Items.Add(new ExceptCharacterRange(FirstValue, LastValue));
			return Sequence;
		}
		public static Sequence ThenExceptCharacterRange(this Predicate Predicate, char FirstValue, char LastValue)
		{
			return new Sequence(Predicate, new ExceptCharacterRange(FirstValue, LastValue));
		}
		public static Sequence Then(this Sequence Sequence, Predicate Value)
		{
			Sequence.Items.Add(Value);
			return Sequence;
		}
		public static Sequence Then(this Predicate Predicate, Predicate Value)
		{
			return new Sequence(Predicate,Value);
		}
		public static Sequence ThenAnyCharacter(this Sequence Sequence)
		{
			Sequence.Items.Add(new AnyCharacter());
			return Sequence;
		}
		public static Sequence ThenAnyCharacter(this Predicate Predicate)
		{
			return new Sequence(Predicate, new AnyCharacter());
		}
		public static Sequence ThenOneOrMoreTimes(this Sequence Predicate, char Value)
		{
			Predicate.Items.Add(new OneOrMoreTimes(new Character(Value)));
			return Predicate;
		}
		public static Sequence ThenOneOrMoreTimes(this Predicate Predicate, Predicate Other)
		{
			return new Sequence(Predicate, new OneOrMoreTimes( Other));
		}
		public static Sequence ThenOneOrMoreTimes(this Predicate Predicate, char Value)
		{
			return new Sequence(Predicate, new OneOrMoreTimes( new Character(Value)) );
		}
		public static Sequence ThenOneOrMoreTimes(this Sequence Predicate, Predicate Other)
		{
			Predicate.Items.Add(new OneOrMoreTimes(Other));
			return Predicate;
		}
		public static Sequence ThenZeroOrMoreTimes(this Sequence Predicate, char Value)
		{
			Predicate.Items.Add(new ZeroOrMoreTimes(new Character(Value)));
			return Predicate;
		}
		public static Sequence ThenZeroOrMoreTimes(this Predicate Predicate, Predicate Other)
		{
			return new Sequence(Predicate, new ZeroOrMoreTimes(Other));
		}
		public static Sequence ThenZeroOrMoreTimes(this Predicate Predicate, char Value)
		{
			return new Sequence(Predicate, new ZeroOrMoreTimes(new Character(Value)));
		}
		public static Sequence ThenZeroOrMoreTimes(this Sequence Predicate, Predicate Other)
		{
			Predicate.Items.Add(new ZeroOrMoreTimes(Other));
			return Predicate;
		}
		public static Sequence ThenPerhaps(this Sequence Predicate, char Value)
		{
			Predicate.Items.Add(new Perhaps(new Character(Value)));
			return Predicate;
		}
		public static Sequence ThenPerhaps(this Predicate Predicate, Predicate Other)
		{
			return new Sequence(Predicate, new Perhaps(Other));
		}
		public static Sequence ThenPerhaps(this Predicate Predicate, char Value)
		{
			return new Sequence(Predicate, new Perhaps(new Character(Value)));
		}
		public static Sequence ThenPerhaps(this Sequence Predicate, Predicate Other)
		{
			Predicate.Items.Add(new Perhaps(Other));
			return Predicate;
		}
		#endregion


		#region Or generators
		public static Or OrCharacter(this Or Or, char Value)
		{
			Or.Items.Add(new Character(Value));
			return Or;
		}
		public static Or OrCharacter(this Predicate Predicate, char Value)
		{
			return new Or(Predicate, new Character(Value));
		}
		public static Or OrExceptCharacter(this Or Or, char Value)
		{
			Or.Items.Add(new ExceptCharacter(Value));
			return Or;
		}
		public static Or OrExceptCharacter(this Predicate Predicate, char Value)
		{
			return new Or(Predicate, new ExceptCharacter(Value));
		}
		public static Or OrCharacterRange(this Or Or, char FirstValue, char LastValue)
		{
			Or.Items.Add(new CharacterRange(FirstValue, LastValue));
			return Or;
		}
		public static Or OrCharacterRange(this Predicate Predicate, char FirstValue, char LastValue)
		{
			return new Or(Predicate, new CharacterRange(FirstValue, LastValue));
		}
		public static Or OrExceptCharacterRange(this Or Or, char FirstValue, char LastValue)
		{
			Or.Items.Add(new ExceptCharacterRange(FirstValue, LastValue));
			return Or;
		}
		public static Or OrExceptCharacterRange(this Predicate Predicate, char FirstValue, char LastValue)
		{
			return new Or(Predicate, new ExceptCharacterRange(FirstValue, LastValue));
		}
		public static Or Or(this Or Or, Predicate Value)
		{
			Or.Items.Add(Value);
			return Or;
		}
		public static Or Or(this Predicate Predicate, Predicate Value)
		{
			return new Or(Predicate, Value);
		}
		public static Or OrAnyCharacter(this Or Or)
		{
			Or.Items.Add(new AnyCharacter());
			return Or;
		}
		public static Or OrAnyCharacter(this Predicate Predicate)
		{
			return new Or(Predicate, new AnyCharacter());
		}
		public static Or OrOneOrMoreTimes(this Or Predicate, char Value)
		{
			Predicate.Items.Add(new OneOrMoreTimes(new Character(Value)));
			return Predicate;
		}
		public static Or OrOneOrMoreTimes(this Predicate Predicate, Predicate Other)
		{
			return new Or(Predicate, new OneOrMoreTimes(Other));
		}
		public static Or OrOneOrMoreTimes(this Predicate Predicate, char Value)
		{
			return new Or(Predicate, new OneOrMoreTimes(new Character(Value)));
		}
		public static Or OrOneOrMoreTimes(this Or Predicate, Predicate Other)
		{
			Predicate.Items.Add(new OneOrMoreTimes(Other));
			return Predicate;
		}
		public static Or OrZeroOrMoreTimes(this Or Predicate, char Value)
		{
			Predicate.Items.Add(new ZeroOrMoreTimes(new Character(Value)));
			return Predicate;
		}
		public static Or OrZeroOrMoreTimes(this Predicate Predicate, Predicate Other)
		{
			return new Or(Predicate, new ZeroOrMoreTimes(Other));
		}
		public static Or OrZeroOrMoreTimes(this Predicate Predicate, char Value)
		{
			return new Or(Predicate, new ZeroOrMoreTimes(new Character(Value)));
		}
		public static Or OrZeroOrMoreTimes(this Or Predicate, Predicate Other)
		{
			Predicate.Items.Add(new ZeroOrMoreTimes(Other));
			return Predicate;
		}
		public static Or OrPerhaps(this Or Predicate, char Value)
		{
			Predicate.Items.Add(new Perhaps(new Character(Value)));
			return Predicate;
		}
		public static Or OrPerhaps(this Predicate Predicate, Predicate Other)
		{
			return new Or(Predicate, new Perhaps(Other));
		}
		public static Or OrPerhaps(this Predicate Predicate, char Value)
		{
			return new Or(Predicate, new Perhaps(new Character(Value)));
		}
		public static Or OrPerhaps(this Or Predicate, Predicate Other)
		{
			Predicate.Items.Add(new Perhaps(Other));
			return Predicate;
		}
		#endregion


		#region OneOrMoreTimes generators

		public static OneOrMoreTimes OneOrMoreTimes(this Predicate Predicate)
		{
			return new OneOrMoreTimes(Predicate);
		}
		public static OneOrMoreTimes OneOrMoreTimes(this char Value)
		{
			return new OneOrMoreTimes(new Character(Value));
		}
		
		#endregion


		#region ZeroOrMoreTimes generators

		public static ZeroOrMoreTimes ZeroOrMoreTimes(this Predicate Predicate)
		{
			return new ZeroOrMoreTimes(Predicate);
		}
		public static ZeroOrMoreTimes ZeroOrMoreTimes(this char Value)
		{
			return new ZeroOrMoreTimes(new Character(Value));
		}
		#endregion
		

		#region Perhaps generators
		public static Perhaps Perhaps(this Predicate Predicate)
		{
			return new Perhaps(Predicate);
		}
		public static Perhaps Perhaps(this char Value)
		{
			return new Perhaps(new Character(Value));
		}
		#endregion



	}
}
