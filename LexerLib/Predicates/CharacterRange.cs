using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class CharacterRange : ShiftPredicate, ICharacterRange
	{
		[XmlIgnore]
		char ICharacterRange.FirstValue => FirstValue;
		[XmlAttribute]
		public char FirstValue
		{
			get;
			set;
		}
		[XmlIgnore]
		char ICharacterRange.LastValue => LastValue;
		[XmlAttribute]
		public char LastValue
		{
			get;
			set;
		}


		public CharacterRange()
		{

		}
		public CharacterRange(char FirstValue,char LastValue)
		{
			this.FirstValue = FirstValue;
			this.LastValue = LastValue;
		}

		

		public override bool Accept(char Input)
		{
			return (Input >= FirstValue) && (Input <= LastValue);
		}

		public override string ToString()
		{
			return $"[{FirstValue.ToString()}-{LastValue.ToString()}]";
		}

	}
}
