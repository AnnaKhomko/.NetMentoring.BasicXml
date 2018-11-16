using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Parsers
{
	public class PatentEntityParser
	{
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null");
			}

			var patentEntity = new Patent
			{
				Name = element.Element("Name").Value,
				Creators = element.Element("Creators").Elements("Creator").Select(e => new Creator
				{
					Name = e.Attribute("name").Value,
					Surname = e.Attribute("surname").Value
				}).ToList(),
				Country = element.Element("Country").Value,
				RegistrationNumber = int.Parse(element.Element("RegistrationNumber").Value),
				ApplicationDate = DateTime.Parse(element.Element("ApplicationDate").Value),
				PublicationDate = DateTime.Parse(element.Element("PublicationDate").Value),
				PageCount = int.Parse(element.Element("PageCount").Value),
				Annotation = element.Element("Annotation").Value
			};

			return patentEntity;
		}
	}
}
