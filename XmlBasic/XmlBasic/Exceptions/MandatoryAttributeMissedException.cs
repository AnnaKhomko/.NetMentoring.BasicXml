using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlBasic.Exceptions
{
	public class MandatoryAttributeMissedException : Exception
	{
		public MandatoryAttributeMissedException() : base()
		{ }

		public MandatoryAttributeMissedException(string message) : base(message)
		{ }
	}
}
