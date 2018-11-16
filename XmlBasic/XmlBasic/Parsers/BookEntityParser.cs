using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Parsers
{
	public class BookEntityParser
	{
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null");
			}

			var bookEntity = new Book
			{
				Name = element.Element("Name").Value,
				Authors = element.Element("Authors").Elements("Author").Select(e => new Author
				{
					Name = e.Attribute("name").Value,
					Surname = e.Attribute("surname").Value
				}).ToList(),
				PublicationPlace = element.Element("PublicationPlace").Value,
				PublisherName = element.Element("PublisherName").Value,
				PublicationYear = int.Parse(element.Element("PublicationYear").Value),
				PageCount = int.Parse(element.Element("PageCount").Value),
				Annotation = element.Element("Annotation").Value,
				ISBN = element.Element("ISBN").Value
			};

			return bookEntity;
		}
	}
}
