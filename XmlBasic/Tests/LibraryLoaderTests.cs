using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Comparers;
using XmlBasic;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;

namespace Tests
{
	[TestClass]
	public class LibraryLoaderTests
	{
		private LibraryLoader libraryLoader;

		[TestInitialize]
		public void Init()
		{
			libraryLoader = new LibraryLoader();
		}

		[TestMethod]
		public void ReadFromMethodTest_ExpectedDataReturned()
		{
			var catalogComparer = new CatalogComparer();

			TextReader textReader = new StringReader(@"<?xml version=""1.0"" encoding=""utf - 8"" ?>" +
											"<Library>" +
											@"<Catalog unloadingTime = ""01/20/2006"" libraryName = ""National"" >" +
											GetBookXml() +
											GetNewspaperXml() +
											GetPatentXml() +
											"</Catalog>" +											
											"</Library>");

			var libraryCollection = libraryLoader.ReadFrom(textReader).ToList();

			CollectionAssert.AreEqual(libraryCollection, new[] { CreateCatalog() }, catalogComparer);

			textReader.Dispose();
		}

		[TestMethod]
		public void WriteToMethodTest_ExpectedDataReturned()
		{
			StringBuilder actualResult = new StringBuilder();
			StringWriter stringWriter = new StringWriter(actualResult);

			var catalog = CreateCatalog();
			var entities = new IEntity[] { catalog };

			string expectedResult = @"<?xml version=""1.0"" encoding=""utf-16""?>" +
											"<Library>" +
											@"<Catalog unloadingTime=""01/20/2006"" libraryName=""National"">" +
											GetBookXml() +
											GetNewspaperXml() +
											GetPatentXml() +
											"</Catalog>" +
											"</Library>";

			libraryLoader.WriteTo(stringWriter, entities);

			stringWriter.Dispose();

			Assert.AreEqual(expectedResult, actualResult.ToString());
		}

		#region Create data 

		private Newspaper CreateNewspaper()
		{
			return new Newspaper
			{
				Name = "Times",
				PublicationPlace = "London",
				PublisherName = "London typography",
				PublicationYear = 1904,
				PageCount = 14,
				Date = new DateTime(1905, 5, 16),
				ISSN = "0317-8471",
				Number = 14,
				Annotation = "The most popular London newspaper"
			};
		}

		private Patent CreatePatent()
		{
			return new Patent
			{
				Name = "Airplane",
				Country = "USA",
				RegistrationNumber = 123,
				ApplicationDate = new DateTime(1905, 12, 24),
				PublicationDate = new DateTime(1906, 1, 20),
				PageCount = 100,
				Annotation = "First airplane in the world",
				Creators = new List<Creator>
				{
					new Creator {Name = "Orville", Surname = "Wright"},
					new Creator {Name = "Wilbur", Surname = "Wright"}
				}
			};
		}

		private Book CreateBook()
		{
			return new Book
			{
				Name = "A song of Ice and Fire",
				PublicationPlace = "New-York",
				PublisherName = "Typography",
				PublicationYear = 1999,
				PageCount = 500,
				ISBN = "978-1-56619-909-4",
				Annotation = "This book is about history of Seven Kingdom.",
				Authors = new List<Author>
				{
					new Author {Name = "George", Surname = "Martin"}
				}
			};
		}

		private Catalog CreateCatalog()
		{
			return new Catalog
			{
				LibraryName = "National",
				UploadingTime = new DateTime(2006, 1, 20),
				Book = CreateBook(),
				Newspaper = CreateNewspaper(),
				Patent = CreatePatent()
			};
		}

		#endregion

		#region Get xml data

		private string GetBookXml()
		{
			return "<Book>" +
					"<Name>A song of Ice and Fire</Name>" +
					"<Authors>" +
						@"<Author name=""George"" surname=""Martin"" />" +
					"</Authors>" +
					"<PublicationPlace>New-York</PublicationPlace>" +
					"<PublisherName>Typography</PublisherName>" +
					"<PublicationYear>1999</PublicationYear>" +
					"<PageCount>500</PageCount>" +
					"<Annotation>This book is about history of Seven Kingdom.</Annotation>" +
					"<ISBN>978-1-56619-909-4</ISBN>" +
					"</Book>";
		}

		private string GetNewspaperXml()
		{
			return "<Newspaper>" +
					"<Name>Times</Name>" +
					"<PublicationPlace>London</PublicationPlace>" +
					"<PublisherName>London typography</PublisherName>" +
					"<PublicationYear>1904</PublicationYear>" +
					"<PageCount>14</PageCount>" +
					"<Annotation>The most popular London newspaper</Annotation>" +
					"<Number>14</Number>" +
					"<Date>05/16/1905</Date>" +
					"<ISSN>0317-8471</ISSN>" +
					"</Newspaper>";
			
		}

		private string GetPatentXml()
		{
			return "<Patent>" +
					"<Name>Airplane</Name>" +
					"<Creators>" +
						@"<Creator name=""Orville"" surname=""Wright"" />" +
						@"<Creator name=""Wilbur"" surname=""Wright"" />" +
					"</Creators>" +
					"<Country>USA</Country>" +
					"<RegistrationNumber>123</RegistrationNumber>" +
					"<ApplicationDate>12/24/1905</ApplicationDate>" +
					"<PublicationDate>01/20/1906</PublicationDate>" +
					"<PageCount>100</PageCount>" +
					"<Annotation>First airplane in the world</Annotation>" +
					"</Patent>";
		}

		#endregion
	}
}
