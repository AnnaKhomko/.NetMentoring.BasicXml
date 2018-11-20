using System;

namespace XmlBasic.Exceptions
{
	/// <summary>
	/// Mandatory Attribute Missed Exception class
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class MandatoryAttributeMissedException : Exception
	{
		public MandatoryAttributeMissedException() : base()
		{ }

		public MandatoryAttributeMissedException(string message) : base(message)
		{ }
	}
}
