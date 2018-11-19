using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlBasic.Entities;

namespace Tests.Comparers
{
	public class PatentComparer : IComparer, IComparer<Patent>
	{
		public int Compare(object x, object y)
		{
			return Compare(x as Patent, y as Patent);
		}

		public int Compare(Patent x, Patent y)
		{
			return x.Name == y.Name
					&& x.Annotation == y.Annotation
					&& x.ApplicationDate == y.ApplicationDate
					&& x.Country == y.Country
					&& x.PageCount == y.PageCount
					&& x.Name == y.Name
					&& x.PublicationDate == y.PublicationDate
					&& x.RegistrationNumber == y.RegistrationNumber ? 0 : 1;
		}
	}
}
