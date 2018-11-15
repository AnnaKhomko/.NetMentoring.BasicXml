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
			var bookEntity = new Book
			{
				Name = element.Element("Name").Value
			};

			return bookEntity;
		}
	}
}
