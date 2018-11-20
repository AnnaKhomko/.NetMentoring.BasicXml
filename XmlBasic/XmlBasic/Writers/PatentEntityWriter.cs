using System;
using System.Linq;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Writers.Abstract;

namespace XmlBasic.Writers
{
	/// <summary>
	/// Patent entity writer class
	/// </summary>
	/// <seealso cref="XmlBasic.Writers.Abstract.BaseWriter" />
	public class PatentEntityWriter : BaseWriter
	{
		private static string elementName = "Patent";

		/// <summary>
		/// Writes the entity.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="entity">The entity.</param>
		/// <exception cref="ArgumentException">provided {nameof(entity)} is null or not of type {nameof(Patent)}</exception>
		public void WriteEntity(XElement element, IEntity entity)
		{
			Patent patent = entity as Patent;
			if (patent == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Patent)}");
			}

			XElement elem = new XElement(elementName);
			AddElement(elem, "Name", patent.Name);
			AddElement(elem, "Creators", patent.Creators
				.Select(el => new XElement("Creator", 
							  new XAttribute("name", el.Name), 
							  new XAttribute("surname", el.Surname))));
			AddElement(elem, "Country", patent.Country);
			AddElement(elem, "RegistrationNumber", patent.RegistrationNumber);
			AddElement(elem, "ApplicationDate", GetInvariantShortDateString(patent.ApplicationDate));
			AddElement(elem, "PublicationDate", GetInvariantShortDateString(patent.PublicationDate));
			AddElement(elem, "PageCount", patent.PageCount);
			AddElement(elem, "Annotation", patent.Annotation);
			element.Add(elem);
		}
	}
}
