using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlBasic.Entities;

namespace Tests.Comparers
{
	class NewspaperComparer : IComparer, IComparer<Newspaper>
	{
		public int Compare(object x, object y)
		{
			return Compare(x as Newspaper, y as Newspaper);
		}

		public int Compare(Newspaper x, Newspaper y)
		{
			return x.Name == y.Name 
					&& x.PublicationPlace == y.PublicationPlace 
					&& x.PublisherName == y.PublisherName 
					&& x.PublicationYear == y.PublicationYear 
					&& x.PageCount == y.PageCount 
					&& x.Annotation == y.Annotation 
					&& x.Number == y.Number 
					&& x.Date == y.Date 
					&& x.ISSN == y.ISSN ? 0 : 1;
		}
	}
}
