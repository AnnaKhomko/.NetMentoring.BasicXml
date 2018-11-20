using System;

namespace XmlBasic.Exceptions
{
	/// <summary>
	/// Unknown Element Exception class
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class UnknownElementException : Exception
	{
		public UnknownElementException() : base()
		{ }

		public UnknownElementException(string message) : base(message)
		{ }
	}
}
