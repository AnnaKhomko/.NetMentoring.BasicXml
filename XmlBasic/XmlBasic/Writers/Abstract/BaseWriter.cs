using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Exceptions;

namespace XmlBasic.Writers.Abstract
{
	public abstract class BaseWriter
	{
		protected string GetInvariantShortDateString(DateTime date)
		{
			return date.ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture);
		}

		protected void AddAttribute(XElement element, string attributeName, string value, bool isMandatory = false)
		{
			if (string.IsNullOrWhiteSpace(value) && isMandatory)
			{
				throw new MandatoryAttributeMissedException($"Value of mandatory attribute \"{attributeName}\" is null or empty");
			}

			element.SetAttributeValue(attributeName, value);
		}

		protected void AddElement(XElement element, string newElementName, object value, bool isMandatory = false)
		{
			if (value == null && isMandatory)
			{
				throw new MandatoryElementMissedException($"Value of mandatory element \"{newElementName}\" is null");
			}

			var newElement = new XElement(newElementName, value);
			element.Add(newElement);
		}
	}
}
