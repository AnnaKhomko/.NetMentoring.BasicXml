using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlBasic;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
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

			StringBuilder actualResult = new StringBuilder();
			StringWriter sw = new StringWriter(actualResult);

			var catalog = CreateCatalog();
			var entities = new IEntity [] { catalog };

			TextReader textReader = new StringReader(@"<?xml version=""1.0"" encoding=""utf - 8"" ?>" +
											"<Library>" +
											@"<Catalog unloadingTime = ""Jan 1, 2009"" libraryName = ""Pushkin"" >" +
											"<Book>" +
											"<Name>Petia</Name>" +
											"<Authors>" +
												@"<Author name = ""aaa"" surname = ""bbb""/> " +
											"</Authors>" +
											"<PublicationPlace>Minsk</PublicationPlace>" +
											"<PublisherName>Zvezda</PublisherName>" +
											"<PublicationYear>2017</PublicationYear>" +
											"<PageCount>12</PageCount>" +
											"<Annotation>dfgdfgdfg</Annotation>" +
											"<ISBN>123vnghn34</ISBN>" +
											"</Book>" +
											"<Newspaper>" +
											"<Name>Petianews</Name>" +
											"<PublicationPlace>minsk</PublicationPlace>" +
											"<PublisherName>saw</PublisherName>" +
											"<PublicationYear>2013</PublicationYear>" +
											"<PageCount>34</PageCount>" +
											"<Annotation>wwwwwwww</Annotation>" +
											"<Number>3</Number>" +
											"<Date>Jan 21, 2011</Date>" +
											"<ISSN>fdg34df</ISSN>" +
											"</Newspaper>" +
											"<Patent>" +
											"<Name>Petiapatent</Name>" +
											"<Creators>" +
												@"<Creator name = ""aaa"" surname = ""bbb""/> " +
											"</Creators>" +
											"<Country>Belarus</Country>" +
											"<RegistrationNumber>54</RegistrationNumber>" +
											"<ApplicationDate>Jul 21, 2011</ApplicationDate>" +
											"<PublicationDate>Jul 24, 2011</PublicationDate>" +
											"<PageCount>12</PageCount>" +
											"<Annotation>dfgdfgdfg</Annotation>" +
											"</Patent>" +
											"</Catalog>" +											
											"</Library>");

			var list = libraryLoader.ReadFrom(textReader).ToList();

			libraryLoader.WriteTo(sw, entities);
		}

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
				UploadingTime = new DateTime(1906, 1, 20),
				Book = CreateBook(),
				Newspaper = CreateNewspaper(),
				Patent = CreatePatent()
			};
		}
	}
}
