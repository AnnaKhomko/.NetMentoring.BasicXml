using System;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	/// <summary>
	/// Class contains Catalog entity data
	/// </summary>
	public class Catalog : IEntity
	{
		/// <summary>
		/// Gets or sets the uploading time.
		/// </summary>
		/// <value>
		/// The uploading time.
		/// </value>
		public DateTime UploadingTime { get; set; }

		/// <summary>
		/// Gets or sets the name of the library.
		/// </summary>
		/// <value>
		/// The name of the library.
		/// </value>
		public string LibraryName { get; set; }

		/// <summary>
		/// Gets or sets the book data.
		/// </summary>
		/// <value>
		/// The book.
		/// </value>
		public Book Book { get; set; }

		/// <summary>
		/// Creates newspaper data.
		/// </summary>
		/// <value>
		/// The newspaper.
		/// </value>
		public Newspaper Newspaper { get; set; }

		/// <summary>
		/// Gets or sets the patent data.
		/// </summary>
		/// <value>
		/// The patent.
		/// </value>
		public Patent Patent { get; set; }
	}
}
