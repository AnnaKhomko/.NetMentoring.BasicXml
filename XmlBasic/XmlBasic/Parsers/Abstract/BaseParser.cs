using System;
using System.Globalization;
using System.Xml.Linq;
using XmlBasic.Exceptions;

namespace XmlBasic.Parsers.Abstract
{
	public abstract class BaseParser
	{
		protected string GetAttributeValue(XElement element, string name, bool isMandatory = false)
		{
			var attribute = element.Attribute(name);
			if (string.IsNullOrEmpty(attribute?.Value) && isMandatory)
			{
				throw new MandatoryAttributeMissedException($"{name}");
			}

			return attribute?.Value;
		}

		protected XElement GetElement(XElement parentElement, string name, bool isMandatory = false)
		{
			var element = parentElement.Element(name);
			if (string.IsNullOrWhiteSpace(element?.Value) && isMandatory)
			{
				throw new MandatoryElementMissedException($"{name}");
			}

			return element;
		}

		protected string GetElementValue(XElement parentElement, string name, bool isMandatory = false)
		{
			var element = parentElement.Element(name);
			if (string.IsNullOrWhiteSpace(element?.Value) && isMandatory)
			{
				throw new MandatoryElementMissedException($"{name}");
			}

			return element.Value;
		}

		protected DateTime GetDate(string dateInvariant)
		{
			if (string.IsNullOrWhiteSpace(dateInvariant))
			{
				return default(DateTime);
			}

			return DateTime.ParseExact(dateInvariant, CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern,
				CultureInfo.InvariantCulture.DateTimeFormat);
		}
	}
}
