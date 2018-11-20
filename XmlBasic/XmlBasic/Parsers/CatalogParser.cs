using System;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Exceptions;

namespace XmlBasic.Parsers
{
	/// <summary>
	/// Catalog entity parser class
	/// </summary>
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

		/// <summary>
		/// Parses the element.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns>IEntity object</returns>
		/// <exception cref="XmlBasic.Exceptions.UnknownElementException">Founded unknown element tag: {elem.Name.LocalName}</exception>
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null.");
			}

			var catalogEntity = new Catalog
			{
				UploadingTime = DateTime.Parse(element.Attribute("unloadingTime").Value),
				LibraryName = element.Attribute("libraryName").Value				
			};
			foreach (var node in element.Nodes())
			{
				var elem = XElement.Parse(node.ToString());

				if (elem == null)
				{
					throw new ArgumentNullException($"{nameof(elem)} is null.");
				}

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
