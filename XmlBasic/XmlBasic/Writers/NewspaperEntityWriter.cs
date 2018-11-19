using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Writers.Abstract;

namespace XmlBasic.Writers
{
	public class NewspaperEntityWriter : BaseWriter
	{
		private static string elementName = "Newspaper";

		public void WriteEntity(XElement element, IEntity entity)
		{
			Newspaper newspaper = entity as Newspaper;
			if (newspaper == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Newspaper)}");
			}

			XElement elem = new XElement(elementName);
			AddElement(elem, "Name", newspaper.Name);
			AddElement(elem, "PublicationPlace", newspaper.PublicationPlace);
			AddElement(elem, "PublisherName", newspaper.PublisherName);
			AddElement(elem, "PublicationYear", newspaper.PublicationYear);
			AddElement(elem, "PageCount", newspaper.PageCount);
			AddElement(elem, "Annotation", newspaper.Annotation);
			AddElement(elem, "Number", newspaper.Number);
			AddElement(elem, "Date", newspaper.Date);
			AddElement(elem, "ISSN", newspaper.ISSN);
			element.Add(elem);
		}
	}
}
