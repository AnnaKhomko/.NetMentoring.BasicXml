using System;
using System.Collections.Generic;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	/// <summary>
	/// Class contains Patent entity data
	/// </summary>
	public class Patent : IEntity
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the creators.
		/// </summary>
		/// <value>
		/// The creators.
		/// </value>
		public List<Creator> Creators { get; set; }

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		public string Country { get; set; }

		/// <summary>
		/// Gets or sets the registration number.
		/// </summary>
		/// <value>
		/// The registration number.
		/// </value>
		public int RegistrationNumber { get; set; }

		/// <summary>
		/// Gets or sets the application date.
		/// </summary>
		/// <value>
		/// The application date.
		/// </value>
		public DateTime ApplicationDate { get; set; }

		/// <summary>
		/// Gets or sets the publication date.
		/// </summary>
		/// <value>
		/// The publication date.
		/// </value>
		public DateTime PublicationDate { get; set; }

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
	}
}
