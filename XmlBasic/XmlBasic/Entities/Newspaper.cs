using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	public class Newspaper : ICatalogEntity
	{
		public string Name { get; set; }
		public string PublicationPlace { get; set; }
		public string PublisherName { get; set; }
		public int PublicationYear { get; set; }
		public int PageCount { get; set; }
		public string Annotation { get; set; }
		public int Number { get; set; }
		public DateTime Date { get; set; }
		public string ISSN { get; set; }
	}
}
