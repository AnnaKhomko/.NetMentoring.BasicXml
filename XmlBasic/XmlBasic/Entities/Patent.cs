using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	public class Patent : ICatalogEntity
	{
		public string Name { get; set; }
		public List<Author> Creators { get; set; }
		public string Country { get; set; }
		public int RegistrationNumber { get; set; }
		public DateTime ApplicationDate { get; set; }
		public DateTime PublicationDate { get; set; }
		public int PageCount { get; set; }
		public string Annotation { get; set; }
	}
}
