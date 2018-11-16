using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Parsers
{
	public class NewspaperEntityParser
	{
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null");
			}

			var newspaperEntity = new Newspaper
			{
				Name = element.Element("Name").Value,
				PublicationPlace = element.Element("PublicationPlace").Value,
				PublisherName = element.Element("PublisherName").Value,
				PublicationYear = int.Parse(element.Element("PublicationYear").Value),
				PageCount = int.Parse(element.Element("PageCount").Value),
				Annotation = element.Element("Annotation").Value,
				Number = int.Parse(element.Element("Number").Value),
				Date = DateTime.Parse(element.Element("Date").Value),
				ISSN = element.Element("ISSN").Value
			};

			return newspaperEntity;
		}
	}
}
