using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLib.Predicates
{
	public class Character : ShiftPredicate, ICharacter
	{
		char ICharacter.Value => Value;
		public char Value
		{
			get;
			set;
		}


		public Character()
		{

		}
		public Character(char Value)
		{
			this.Value = Value;
		}

		public static implicit operator Character(char Value)
		{
			return new Character(Value);
		}


	}
}
