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
	public class PatentEntityWriter
	{
		public void WriteEntity(XmlWriter xmlWriter, IEntity entity)
		{
			Patent patent = entity as Patent;
			if (patent == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Patent)}");
			}

			XElement element = new XElement("Patent");
			element.Add("Name", patent.Name);
			element.Add("Creators", patent.Creators
				.Select(el => new XElement("Creator", 
							  new XAttribute("name", el.Name), 
							  new XAttribute("surname", el.Surname))));
			element.Add("Country", patent.Country);
			element.Add("RegistrationNumber", patent.RegistrationNumber);
			element.Add("ApplicationDate", patent.ApplicationDate);
			element.Add("PublicationDate", patent.PublicationDate);
			element.Add("PageCount", patent.PageCount);
			element.Add("Annotation", patent.Annotation);
			element.WriteTo(xmlWriter);
		}
	}
}
