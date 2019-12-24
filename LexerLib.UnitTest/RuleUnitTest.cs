using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using LexerLib.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class RuleUnitTest
	{
		/*[TestMethod]
		public void CreateRuleSample()
		{
			XmlSerializer serializer;
			Rule ruleA;
			Stream stream;

			ruleA = new Rule();
			ruleA.Name = "RuleA";
			ruleA.Predicate = Parse.Character('a').OneOrMoreTimes().Then( Parse.AnyCharacter().OrCharacter('b') ).Then(Parse.Character('d').Perhaps());

			using (stream = new FileStream(@"d:\example.xml",FileMode.Create))
			{
				serializer = new XmlSerializer(typeof(Rule));
				serializer.Serialize(stream, ruleA);
				
			}
			Assert.Fail("Do not run");
		}//*/

		[TestMethod]
		public void ShouldSerializeAndDeserialize()
		{
			XmlSerializer serializer;
			Rule ruleA,ruleB;
			MemoryStream stream;

			ruleA = new Rule();
			ruleA.Name = "RuleA";
			ruleA.Predicate = Parse.Character('a').OneOrMoreTimes();

			using (stream = new MemoryStream())
			{
				serializer = new XmlSerializer(typeof(Rule));
				serializer.Serialize(stream, ruleA);
				stream.Seek(0, SeekOrigin.Begin);
				ruleB=serializer.Deserialize(stream) as Rule;
			}

			Assert.IsNotNull(ruleB);
			Assert.AreEqual(ruleA.Name, ruleB.Name);
		}

		[TestMethod]
		public void ShouldDeserializeFromExample()
		{
			XmlSerializer serializer;
			Rule ruleA;
			Stream stream;


			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			using (stream = assembly.GetManifestResourceStream("LexerLib.UnitTest.example.xml"))
			{
				serializer = new XmlSerializer(typeof(Rule));
				ruleA = serializer.Deserialize(stream) as Rule;
			}

			Assert.IsNotNull(ruleA);
			Assert.IsInstanceOfType(ruleA.Predicate, typeof(Sequence));
		}


	}
}
