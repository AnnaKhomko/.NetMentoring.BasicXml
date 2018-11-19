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
	public class BookEntityWriter : BaseWriter
	{
		private static string elementName = "Book";

		public void WriteEntity(XElement element, IEntity entity)
		{
			Book book = entity as Book;
			if (book == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Book)}");
			}

			XElement elem = new XElement(elementName);
			AddElement(elem, "Name", book.Name);
			AddElement(elem, "Authors", book.Authors
				.Select(el => new XElement("Author",
							  new XAttribute("name", el.Name),
							  new XAttribute("surname", el.Surname))));
			AddElement(elem, "PublicationPlace", book.PublicationPlace);
			AddElement(elem, "PublisherName", book.PublisherName);
			AddElement(elem, "PublicationYear", book.PublicationYear);
			AddElement(elem, "PageCount", book.PageCount);
			AddElement(elem, "Annotation", book.Annotation);
			AddElement(elem, "ISBN", book.ISBN);
			element.Add(elem);
		}
	}
}
