using System;
using System.Globalization;
using System.Xml.Linq;
using XmlBasic.Exceptions;

namespace XmlBasic.Writers.Abstract
{
	/// <summary>
	/// Base writer class
	/// </summary>
	public abstract class BaseWriter
	{
		/// <summary>
		/// Gets the invariant short date string.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		protected string GetInvariantShortDateString(DateTime date)
		{
			return date.ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Adds the attribute.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <param name="value">The value.</param>
		/// <param name="isMandatory">if set to <c>true</c> [is mandatory].</param>
		/// <exception cref="XmlBasic.Exceptions.MandatoryAttributeMissedException">Value of mandatory attribute \"{attributeName}</exception>
		protected void AddAttribute(XElement element, string attributeName, string value, bool isMandatory = false)
		{
			if (string.IsNullOrWhiteSpace(value) && isMandatory)
			{
				throw new MandatoryAttributeMissedException($"Value of mandatory attribute \"{attributeName}\" is null or empty");
			}

			element.SetAttributeValue(attributeName, value);
		}

		/// <summary>
		/// Adds the element.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="newElementName">New name of the element.</param>
		/// <param name="value">The value.</param>
		/// <param name="isMandatory">if set to <c>true</c> [is mandatory].</param>
		/// <exception cref="XmlBasic.Exceptions.MandatoryElementMissedException">Value of mandatory element \"{newElementName}</exception>
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
