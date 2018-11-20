using System.Collections.Generic;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	/// <summary>
	/// Class contains Book entity data
	/// </summary>
	public class Book : IEntity
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the authors.
		/// </summary>
		/// <value>
		/// The authors.
		/// </value>
		public List<Author> Authors{ get; set;}

		/// <summary>
		/// Gets or sets the publication place.
		/// </summary>
		/// <value>
		/// The publication place.
		/// </value>
		public string PublicationPlace { get; set; }

		/// <summary>
		/// Gets or sets the name of the publisher.
		/// </summary>
		/// <value>
		/// The name of the publisher.
		/// </value>
		public string PublisherName { get; set; }

		/// <summary>
		/// Gets or sets the publication year.
		/// </summary>
		/// <value>
		/// The publication year.
		/// </value>
		public int PublicationYear { get; set; }

		/// <summary>
		/// Gets or sets the page count.
		/// </summary>
		/// <value>
		/// The page count.
		/// </value>
		public int PageCount { get; set; }

		/// <summary>
		/// Gets or sets the annotation.
		/// </summary>
		/// <value>
		/// The annotation.
		/// </value>
		public string Annotation { get; set; }

		/// <summary>
		/// Gets or sets the isbn.
		/// </summary>
		/// <value>
		/// The isbn.
		/// </value>
		public string ISBN { get; set; }
	}
}
