using System.Collections;
using System.Collections.Generic;
using XmlBasic.Entities;

namespace Tests.Comparers
{
	/// <summary>
	/// Class to compare Catalog Entities
	/// </summary>
	/// <seealso cref="System.Collections.IComparer" />
	/// <seealso cref="System.Collections.Generic.IComparer{XmlBasic.Entities.Catalog}" />
	public class CatalogComparer : IComparer, IComparer<Catalog>
	{
		private BookComparer bookComparer;
		private NewspaperComparer newspaperComparer;
		private PatentComparer patentComparer;

		public CatalogComparer()
		{
			bookComparer = new BookComparer();
			newspaperComparer = new NewspaperComparer();
			patentComparer = new PatentComparer();
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
		public int Compare(Catalog x, Catalog y)
		{
			return x.UploadingTime == y.UploadingTime
				   && x.LibraryName == y.LibraryName
				   && bookComparer.Compare(x.Book, y.Book).Equals(0)
				   && newspaperComparer.Compare(x.Newspaper, y.Newspaper).Equals(0)
				   && patentComparer.Compare(x.Patent, y.Patent).Equals(0) ? 0 : 1;
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
		public int Compare(object x, object y)
		{
			return Compare(x as Catalog, y as Catalog);
		}
	}
}
