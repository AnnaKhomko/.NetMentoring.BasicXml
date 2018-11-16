using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Writers
{
	public class BookEntityWriter
	{
		public void WriteEntity(XmlWriter xmlWriter, IEntity entity)
		{
			Book book = entity as Book;
			if (book == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Book)}");
			}

			XElement element = new XElement("Book");
			element.Add("Name", book.Name);
			element.Add("Authors", book.Authors
				.Select(el => new XElement("Author",
							  new XAttribute("name", el.Name),
							  new XAttribute("surname", el.Surname))));
			element.Add("PublicationPlace", book.PublicationPlace);
			element.Add("PublisherName", book.PublisherName);
			element.Add("PublicationYear", book.PublicationYear);
			element.Add("PageCount", book.PageCount);
			element.Add("Annotation", book.Annotation);
			element.Add("ISBN", book.ISBN);
			element.WriteTo(xmlWriter);
		}
	}
}
