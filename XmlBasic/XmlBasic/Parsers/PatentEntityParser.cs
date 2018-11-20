using System;
using System.Linq;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;
using XmlBasic.Parsers.Abstract;

namespace XmlBasic.Parsers
{
	/// <summary>
	/// Patent entity parser class
	/// </summary>
	/// <seealso cref="XmlBasic.Parsers.Abstract.BaseParser" />
	public class PatentEntityParser : BaseParser
	{
		/// <summary>
		/// Parses the element.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns>IEntity object</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public IEntity ParseElement(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException($"{nameof(element)} is null.");
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
