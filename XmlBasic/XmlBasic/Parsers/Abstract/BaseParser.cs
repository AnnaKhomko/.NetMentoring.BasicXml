using System;
using System.Globalization;
using System.Xml.Linq;
using XmlBasic.Exceptions;

namespace XmlBasic.Parsers.Abstract
{
	/// <summary>
	/// Base parser class
	/// </summary>
	public abstract class BaseParser
	{
		/// <summary>
		/// Gets the attribute value.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="name">The name.</param>
		/// <param name="isMandatory">if set to <c>true</c> [is mandatory].</param>
		/// <returns></returns>
		/// <exception cref="XmlBasic.Exceptions.MandatoryAttributeMissedException"></exception>
		protected string GetAttributeValue(XElement element, string name, bool isMandatory = false)
		{
			var attribute = element.Attribute(name);
			if (string.IsNullOrEmpty(attribute?.Value) && isMandatory)
			{
				throw new MandatoryAttributeMissedException($"{name}");
			}

			return attribute?.Value;
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="parentElement">The parent element.</param>
		/// <param name="name">The name.</param>
		/// <param name="isMandatory">if set to <c>true</c> [is mandatory].</param>
		/// <returns></returns>
		/// <exception cref="XmlBasic.Exceptions.MandatoryElementMissedException"></exception>
		protected XElement GetElement(XElement parentElement, string name, bool isMandatory = false)
		{
			var element = parentElement.Element(name);
			if (string.IsNullOrWhiteSpace(element?.Value) && isMandatory)
			{
				throw new MandatoryElementMissedException($"{name}");
			}

			return element;
		}

		/// <summary>
		/// Gets the element value.
		/// </summary>
		/// <param name="parentElement">The parent element.</param>
		/// <param name="name">The name.</param>
		/// <param name="isMandatory">if set to <c>true</c> [is mandatory].</param>
		/// <returns></returns>
		/// <exception cref="XmlBasic.Exceptions.MandatoryElementMissedException"></exception>
		protected string GetElementValue(XElement parentElement, string name, bool isMandatory = false)
		{
			return GetElement(parentElement, name, isMandatory).Value;
		}

		/// <summary>
		/// Gets the date.
		/// </summary>
		/// <param name="dateInvariant">The date invariant.</param>
		/// <returns></returns>
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
