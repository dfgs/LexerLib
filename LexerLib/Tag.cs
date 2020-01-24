using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LexerLib
{
	[Serializable]
	public  class Tag
	{
		[XmlAttribute]
		public string Name
		{
			get;
			set;
		}
		[XmlAttribute]
		public string Value
		{
			get;
			set;
		}

		public Tag()
		{

		}
		public Tag(string Name)
		{
			this.Name = Name;
		}
		public Tag(string Name,string Value)
		{
			this.Name = Name;this.Value = Value;
		}
	}
}
