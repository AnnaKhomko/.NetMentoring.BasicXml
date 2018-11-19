using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Parsers.Abstract;

namespace XmlBasic.Parsers
{
	public class NewspaperEntityParser : BaseParser
	{
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null");
			}

			var newspaperEntity = new Newspaper
			{
				Name = GetElementValue(element, "Name"),
				PublicationPlace = GetElementValue(element, "PublicationPlace"),
				PublisherName = GetElementValue(element, "PublisherName"),
				PublicationYear = int.Parse(GetElementValue(element, "PublicationYear") ?? default(int).ToString()),
				PageCount = int.Parse(GetElementValue(element, "PageCount") ?? default(int).ToString()),
				Annotation = GetElementValue(element, "Annotation"),
				Number = int.Parse(GetElementValue(element, "Number") ?? default(int).ToString()),
				Date = GetDate(GetElementValue(element, "Date")),
				ISSN = GetElementValue(element, "ISSN")
			};

			return newspaperEntity;
		}
	}
}
