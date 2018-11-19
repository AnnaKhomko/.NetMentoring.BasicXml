using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Writers.Abstract;

namespace XmlBasic.Writers
{
	public class PatentEntityWriter : BaseWriter
	{
		private static string elementName = "Patent";

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
			AddElement(elem, "ApplicationDate", patent.ApplicationDate);
			AddElement(elem, "PublicationDate", patent.PublicationDate);
			AddElement(elem, "PageCount", patent.PageCount);
			AddElement(elem, "Annotation", patent.Annotation);
			element.Add(elem);
		}
	}
}
