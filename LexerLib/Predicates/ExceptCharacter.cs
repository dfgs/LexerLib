using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class ExceptCharacter : ShiftPredicate, IExceptCharacter
	{
		[XmlIgnore]
		char IExceptCharacter.Value => Value;
		[XmlAttribute]
		public char Value
		{
			get;
			set;
		}


		public ExceptCharacter()
		{

		}
		public ExceptCharacter(char Value)
		{
			this.Value = Value;
		}

		

		public override bool Accept(char Input)
		{
			return Input != Value;
		}

		public override string ToString()
		{
			return $"!{Value.ToString()}";
		}

	}
}
