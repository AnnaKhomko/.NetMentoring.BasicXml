using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlBasic.Exceptions
{
	public class MandatoryElementMissedException : Exception
	{
		public MandatoryElementMissedException() : base()
		{ }

		public MandatoryElementMissedException(string message) : base(message)
		{ }
	}
}
