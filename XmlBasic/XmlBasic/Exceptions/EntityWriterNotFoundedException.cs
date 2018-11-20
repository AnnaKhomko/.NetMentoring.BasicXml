using System;

namespace XmlBasic.Exceptions
{
	/// <summary>
	/// Entity Writer Not Founded Exception class
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class EntityWriterNotFoundedException : Exception
	{
		public EntityWriterNotFoundedException() : base()
		{ }

		public EntityWriterNotFoundedException(string message) : base(message)
		{ }
	}
}
