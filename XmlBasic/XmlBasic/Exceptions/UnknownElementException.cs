using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlBasic.Exceptions
{
	public class UnknownElementException : Exception
	{
		public UnknownElementException() : base()
		{ }

		public UnknownElementException(string message) : base(message)
		{ }
	}
}
