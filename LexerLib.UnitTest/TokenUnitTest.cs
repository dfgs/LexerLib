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

		[TestMethod]
		public void ShouldEqual()
		{
			Token A,B;

			A = new Token("C", "V");
			B = new Token("C", "V");

			Assert.IsTrue(A == B);
			Assert.IsFalse(A != B);
			Assert.IsTrue(A.Equals(B));
			Assert.IsTrue(B.Equals(A));
			Assert.IsFalse(A.Equals("toto"));
		}

		[TestMethod]
		public void ShouldNotEqual()
		{
			Token A, B;

			A = new Token("C1", "V");
			B = new Token("C2", "V");

			Assert.IsFalse(A == B);
			Assert.IsTrue(A != B);

			A = new Token("C", "V1");
			B = new Token("C", "V2");

			Assert.IsFalse(A == B);
			Assert.IsTrue(A != B);

		}

		[TestMethod]
		public void ShouldReturnGetHashCode()
		{
			Token A, B;

			A = new Token("C", "V");
			B = new Token("C", "V");
			Assert.AreEqual(A.GetHashCode(), B.GetHashCode());

			A = new Token(null, "V");
			B = new Token("V", null);
			Assert.AreNotEqual(A.GetHashCode(), B.GetHashCode());

			A = new Token("C", "V");
			B = new Token("V", "C");
			Assert.AreNotEqual(A.GetHashCode(), B.GetHashCode());

		}



	}
}
