using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Exceptions;
using XmlBasic.Parsers;
using XmlBasic.Writers;

namespace XmlBasic
{
	/// <summary>
	/// Library loader class
	/// </summary>
	public class LibraryLoader
    {
		private static string elementName = "Library";
		private CatalogParser parser;
		private CatalogEntityWriter writer;

		public LibraryLoader()
		{
			parser = new CatalogParser();
			writer = new CatalogEntityWriter();
		}

		/// <summary>
		/// Reads from.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		/// <exception cref="UnknownElementException">Founded unknown element tag: {node.Name.LocalName}</exception>
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

		/// <summary>
		/// Converts to .
		/// </summary>
		/// <param name="output">The output.</param>
		/// <param name="catalogs">The catalogs.</param>
		/// <exception cref="EntityWriterNotFoundedException">Cannot find entity writer for type {catalogEntity.GetType().FullName}</exception>
		public void WriteTo(TextWriter output, IEnumerable<IEntity> catalogs)
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(output, new XmlWriterSettings()))
			{
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement(elementName);
				foreach (var catalogEntity in catalogs)
				{
					if (catalogEntity.GetType().Equals(typeof(Catalog)))
					{
						writer.WriteEntity(xmlWriter, catalogEntity);
					}
					else
					{
						throw new EntityWriterNotFoundedException($"Cannot find entity writer for type {catalogEntity.GetType().FullName}");
					}
				}
				xmlWriter.WriteEndElement();
			}
		}
	}
}
