using System.Collections;
using System.Collections.Generic;
using XmlBasic.Entities;

namespace Tests.Comparers
{
	/// <summary>
	/// Class to compare Newspaper entities
	/// </summary>
	/// <seealso cref="System.Collections.IComparer" />
	/// <seealso cref="System.Collections.Generic.IComparer{XmlBasic.Entities.Book}" />
	public class NewspaperComparer : IComparer, IComparer<Newspaper>
	{
		/// <summary>
		/// Compares two objects and returns a value indicating whether one is equal to the other.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>
		/// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table
		/// <paramref name="x" /> equals <paramref name="y" />. Zero
		/// <paramref name="x" /> doesn't equal <paramref name="y" />. One
		/// </returns>
		public int Compare(object x, object y)
		{
			return Compare(x as Newspaper, y as Newspaper);
		}

		/// <summary>
		/// Compares two objects and returns a value indicating whether one is equal to the other.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>
		/// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table
		/// <paramref name="x" /> equals <paramref name="y" />. Zero
		/// <paramref name="x" /> doesn't equal <paramref name="y" />. One
		/// </returns>
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
