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
	public class CatalogEntityWriter
	{
		private BookEntityWriter bookWriter;
		private NewspaperEntityWriter newspaperWriter;
		private PatentEntityWriter patentWriter;

		public CatalogEntityWriter()
		{
			bookWriter = new BookEntityWriter();
			newspaperWriter = new NewspaperEntityWriter();
			patentWriter = new PatentEntityWriter();
		}

		public void WriteEntity(XmlWriter xmlWriter, IEntity entity)
		{
			Catalog catalog = entity as Catalog;
			if (catalog == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Catalog)}");
			}

			XElement element = new XElement("Catalog");
			bookWriter.WriteEntity(xmlWriter, catalog.Book);
			newspaperWriter.WriteEntity(xmlWriter, catalog.Newspaper);
			patentWriter.WriteEntity(xmlWriter, catalog.Patent);
			element.WriteTo(xmlWriter);
		}
	}
}
