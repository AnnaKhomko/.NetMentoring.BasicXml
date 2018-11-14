using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Entities
{
	public class CatalogEntity : IEntity
	{
		public DateTime UploadingTime { get; set; }
		public string LibraryName { get; set; }
		public Book Book { get; set; }
		public Newspaper Newspaper { get; set; }
		public Patent Patent { get; set; }
	}
}
