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
	public class NewspaperEntityWriter
	{
		public void WriteEntity(XmlWriter xmlWriter, IEntity entity)
		{
			Newspaper newspaper = entity as Newspaper;
			if (newspaper == null)
			{
				throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Newspaper)}");
			}

			XElement element = new XElement("Newspaper");
			element.Add("Name", newspaper.Name);
			element.Add("PublicationPlace", newspaper.PublicationPlace);
			element.Add("PublisherName", newspaper.PublisherName);
			element.Add("PublicationYear", newspaper.PublicationYear);
			element.Add("PageCount", newspaper.PageCount);
			element.Add("Annotation", newspaper.Annotation);
			element.Add("Number", newspaper.Number);
			element.Add("Date", newspaper.Date);
			element.Add("ISSN", newspaper.ISSN);
			element.WriteTo(xmlWriter);
		}
	}
}
