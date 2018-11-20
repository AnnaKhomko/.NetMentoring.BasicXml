using System;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Writers.Abstract;

namespace XmlBasic.Writers
{
	/// <summary>
	/// Catalog entity writer class
	/// </summary>
	/// <seealso cref="XmlBasic.Writers.Abstract.BaseWriter" />
	public class CatalogEntityWriter : BaseWriter
	{
		private BookEntityWriter bookWriter;
		private NewspaperEntityWriter newspaperWriter;
		private PatentEntityWriter patentWriter;

		private static string elementName = "Catalog";

		public CatalogEntityWriter()
		{
			bookWriter = new BookEntityWriter();
			newspaperWriter = new NewspaperEntityWriter();
			patentWriter = new PatentEntityWriter();
		}

		/// <summary>
		/// Writes the entity.
		/// </summary>
		/// <param name="xmlWriter">The XML writer.</param>
		/// <param name="entity">The entity.</param>
		/// <exception cref="ArgumentException">provided {nameof(entity)} is null or not of type {nameof(Catalog)}</exception>
		public void WriteEntity(XmlWriter xmlWriter, IEntity entity)
		{
			Catalog catalog = entity as Catalog;
			if (catalog == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Catalog)}");
			}

			XElement element = new XElement(elementName);
			AddAttribute(element, "unloadingTime", GetInvariantShortDateString(catalog.UploadingTime));
			AddAttribute(element, "libraryName", catalog.LibraryName);
			bookWriter.WriteEntity(element, catalog.Book);
			newspaperWriter.WriteEntity(element, catalog.Newspaper);
			patentWriter.WriteEntity(element, catalog.Patent);
			element.WriteTo(xmlWriter);
		}
	}
}
