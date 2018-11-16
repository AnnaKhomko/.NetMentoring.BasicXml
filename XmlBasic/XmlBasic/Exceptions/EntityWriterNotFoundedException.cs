using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlBasic.Exceptions
{
	public class EntityWriterNotFoundedException : Exception
	{
		public EntityWriterNotFoundedException() : base()
		{ }

		public EntityWriterNotFoundedException(string message) : base(message)
		{ }
	}
}
