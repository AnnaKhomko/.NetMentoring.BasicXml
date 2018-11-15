using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Exceptions;
using XmlBasic.Parsers;

namespace XmlBasic
{
    public class LibraryLoader
    {
		public LibraryLoader()
		{
			parser = new CatalogParser();
		}
		private static string elementName = "Library";
		private CatalogParser parser;
		public IEnumerable<IEntity> ReadFrom(TextReader input)
		{
			using (XmlReader xmlReader = XmlReader.Create(input, new XmlReaderSettings
			{
				IgnoreWhitespace = true,
				IgnoreComments = true
			}))
			{
				xmlReader.ReadToFollowing(elementName);
				xmlReader.ReadStartElement();

				do
				{
					while (xmlReader.NodeType == XmlNodeType.Element)
					{
						var node = XNode.ReadFrom(xmlReader) as XElement;
						
						if (node.Name.LocalName.Equals("Catalog"))
						{
							yield return parser.ParseElement(node);
						}
						else
						{
							throw new UnknownElementException($"Founded unknown element tag: {node.Name.LocalName}");
						}
					}
				} while (xmlReader.Read());
			}
		}
    }
}
