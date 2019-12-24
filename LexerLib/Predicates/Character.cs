using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class Character : ShiftPredicate, ICharacter
	{
		[XmlIgnore]
		char ICharacter.Value => Value;
		[XmlAttribute]
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

		public override bool Accept(char Input)
		{
			return Input == Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

	}
}
