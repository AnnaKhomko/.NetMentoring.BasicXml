using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Exceptions;

namespace XmlBasic.Parsers
{
	public class CatalogParser
	{
		private BookEntityParser bookParser;
		private NewspaperEntityParser newspaperParser;
		private PatentEntityParser patentParser;

		public CatalogParser()
		{
			bookParser = new BookEntityParser();
			newspaperParser = new NewspaperEntityParser();
			patentParser = new PatentEntityParser();
		}

		public IEntity ParseElement(XElement element)
		{
			var catalogEntity = new Catalog
			{
				UploadingTime = DateTime.Parse(element.Attribute("unloadingTime").Value),
				LibraryName = element.Attribute("libraryName").Value				
		};
			foreach (var node in element.Nodes())
			{
				var elem = XElement.Parse(node.ToString());

				switch (elem.Name.LocalName)
				{
					case "Book":
						{
							catalogEntity.Book = (Book)bookParser.ParseElement(elem);
							break;
						}
					case "Newspaper":
						{
							catalogEntity.Newspaper = (Newspaper)newspaperParser.ParseElement(elem);
							break;
						}
					case "Patent":
						{
							catalogEntity.Patent = (Patent)patentParser.ParseElement(elem);
							break;
						}
					default:
						{
							throw new UnknownElementException($"Founded unknown element tag: {elem.Name.LocalName}");
						}
				}
								
			}			
			return catalogEntity;
		}
	}
}
