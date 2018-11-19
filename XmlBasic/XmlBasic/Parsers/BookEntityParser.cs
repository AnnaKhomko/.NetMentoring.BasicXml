using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Parsers.Abstract;

namespace XmlBasic.Parsers
{
	public class BookEntityParser : BaseParser
	{
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null");
			}

			var bookEntity = new Book
			{
				Name = GetElementValue(element, "Name"),
				Authors = GetElement(element, "Authors").Elements("Author").Select(e => new Author
				{
					Name = GetAttributeValue(e, "name"),
					Surname = GetAttributeValue(e, "surname")
				}).ToList(),
				PublicationPlace = GetElementValue(element, "PublicationPlace"),
				PublisherName = GetElementValue(element, "PublisherName"),
				PublicationYear = int.Parse(GetElementValue(element, "PublicationYear") ?? default(int).ToString()),
				PageCount = int.Parse(GetElementValue(element, "PageCount") ?? default(int).ToString()),
				Annotation = GetElementValue(element, "Annotation"),
				ISBN = GetElementValue(element, "ISBN")
			};

			return bookEntity;
		}
	}
}
