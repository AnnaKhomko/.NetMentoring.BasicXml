using System.Collections;
using System.Collections.Generic;
using XmlBasic.Entities;

namespace Tests.Comparers
{
	public class BookComparer : IComparer, IComparer<Book>
    {
        public int Compare(Book x, Book y)
		{
			return x.Name == y.Name
				   && x.ISBN == y.ISBN
				   && x.Annotation == y.Annotation
				   && x.PageCount == y.PageCount
				   && x.PublicationYear == y.PublicationYear
				   && x.PublicationPlace == y.PublicationPlace
				   && x.PublisherName == y.PublisherName ? 0 : 1;
		}

		public int Compare(object x, object y)
		{
			return Compare(x as Book, y as Book);
		}
	}
}
