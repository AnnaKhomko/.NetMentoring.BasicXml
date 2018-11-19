using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Parsers.Abstract;

namespace XmlBasic.Parsers
{
	public class PatentEntityParser : BaseParser
	{
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null");
			}

			var patentEntity = new Patent
			{
				Name = GetElementValue(element, "Name"),
				Creators = GetElement(element, "Creators").Elements("Creator").Select(e => new Creator
				{
					Name = GetAttributeValue(e, "name"),
					Surname = GetAttributeValue(e, "surname")
				}).ToList(),
				Country = GetElementValue(element, "Country"),
				RegistrationNumber = int.Parse(GetElementValue(element, "RegistrationNumber") ?? default(int).ToString()),
				ApplicationDate = GetDate(GetElementValue(element, "ApplicationDate")),
				PublicationDate = GetDate(GetElementValue(element, "PublicationDate") ?? default(int).ToString()),
				PageCount = int.Parse(GetElementValue(element, "PageCount") ?? default(int).ToString()),
				Annotation = GetElementValue(element, "Annotation")
			};

			return patentEntity;
		}
	}
}
