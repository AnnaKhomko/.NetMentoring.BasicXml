using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlBasic.Parsers;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var entity = new BookEntityParser();
			entity.ReadFrom("XMLFile1.xml");
		}
	}
}
