using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	public class Book : ICatalogEntity
	{
		public string Name { get; set; }
		public List<Author> Authors{ get; set;}
		public string PublicationPlace { get; set; }
		public string PublisherName { get; set; }
		public int PublicationYear { get; set; }
		public int PageCount { get; set; }
		public string Annotation { get; set; }
		public string ISBN { get; set; }
	}
}
