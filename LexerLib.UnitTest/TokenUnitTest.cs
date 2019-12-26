using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLib.UnitTest
{
	[TestClass]
	public class TokenUnitTest
	{
		[TestMethod]
		public void ShouldConvertToString()
		{
			string result;

			result = new Token("Class", "Value").ToString();
			Assert.AreEqual("<Class,Value>", result);

			result = new Token(null, "Value").ToString();
			Assert.AreEqual("<,Value>", result);

			result = new Token("Class", null).ToString();
			Assert.AreEqual("<Class,>", result);

		}
	}
}
