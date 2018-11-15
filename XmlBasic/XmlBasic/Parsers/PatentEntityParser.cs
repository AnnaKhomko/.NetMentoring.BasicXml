using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasic.Entities;
using XmlBasic.Entities.Interfaces;

namespace XmlBasic.Parsers
{
	public class PatentEntityParser
	{
		public IEntity ParseElement(XElement element)
		{
			var patentEntity = new Patent
			{
				Name = element.Element("Name").Value
			};

			return patentEntity;
		}
	}
}
