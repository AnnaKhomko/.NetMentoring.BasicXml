using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlBasic;
using XmlBasic.Entities;
using XmlBasic.Parsers;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var libraryLoader = new LibraryLoader();
			TextReader textReader = new StringReader(@"<?xml version=""1.0"" encoding=""utf - 8"" ?>" +
											"<Library>" +
											@"<Catalog unloadingTime = ""Jan 1, 2009"" libraryName = ""Pushkin"" >" +
											"<Book>" +
											"<Name>Petia</Name>" +
											"</Book>" +
											"<Newspaper>" +
											"<Name>Petianews</Name>" +
											"</Newspaper>" +
											"</Catalog>" +
											@"<Catalog unloadingTime = ""Jan 21, 2011"" libraryName = ""Chehow"" >" +
											"<Book>" +
											"<Name>Vasia</Name>" +
											"</Book>" +
											"<Patent>" +
											"<Name>Petiapatent</Name>" +
											"</Patent>" +
											"</Catalog>" +
											"</Library>");

			var list = libraryLoader.ReadFrom(textReader).ToList();			
		}
	}
}
