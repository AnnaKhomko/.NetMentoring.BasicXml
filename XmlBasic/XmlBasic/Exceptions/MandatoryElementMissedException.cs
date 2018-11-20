using System;

namespace XmlBasic.Exceptions
{
	/// <summary>
	/// Mandatory Element Missed Exception class
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class MandatoryElementMissedException : Exception
	{
		public MandatoryElementMissedException() : base()
		{ }

		public MandatoryElementMissedException(string message) : base(message)
		{ }
	}
}
