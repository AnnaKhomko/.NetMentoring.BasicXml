﻿using System.Collections;
using System.Collections.Generic;
using XmlBasic.Entities;

namespace Tests.Comparers
{
	/// <summary>
	/// Class to compare Book entities
	/// </summary>
	/// <seealso cref="System.Collections.IComparer" />
	/// <seealso cref="System.Collections.Generic.IComparer{XmlBasic.Entities.Book}" />
	public class BookComparer : IComparer, IComparer<Book>
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
			return Compare(x as Book, y as Book);
		}
	}
}
