using System;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Writers.Abstract;

namespace XmlBasic.Writers
{
	/// <summary>
	/// Newspaper entity writer class
	/// </summary>
	/// <seealso cref="XmlBasic.Writers.Abstract.BaseWriter" />
	public class NewspaperEntityWriter : BaseWriter
	{
		private static string elementName = "Newspaper";

		/// <summary>
		/// Writes the entity.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="entity">The entity.</param>
		/// <exception cref="ArgumentException">provided {nameof(entity)} is null or not of type {nameof(Newspaper)}</exception>
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
			AddElement(elem, "Date", GetInvariantShortDateString(newspaper.Date));
			AddElement(elem, "ISSN", newspaper.ISSN);
			element.Add(elem);
		}
	}
}
