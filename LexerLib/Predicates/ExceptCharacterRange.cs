using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib.Predicates
{
	public class ExceptCharacterRange : ShiftPredicate, IExceptCharacterRange
	{
		[XmlIgnore]
		char IExceptCharacterRange.FirstValue => FirstValue;
		[XmlAttribute]
		public char FirstValue
		{
			get;
			set;
		}
		[XmlIgnore]
		char IExceptCharacterRange.LastValue => LastValue;
		[XmlAttribute]
		public char LastValue
		{
			get;
			set;
		}


		public ExceptCharacterRange()
		{

		}
		public ExceptCharacterRange(char FirstValue,char LastValue)
		{
			this.FirstValue = FirstValue;
			this.LastValue = LastValue;
		}

		

		public override bool Accept(char Input)
		{
			return (Input < FirstValue) || (Input > LastValue);
		}

		public override string ToString()
		{
			return $"![{FirstValue.ToString()}-{LastValue.ToString()}]";
		}

	}
}
