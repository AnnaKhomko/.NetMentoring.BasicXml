using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlBasic.Parsers
{
	public class BookEntityParser
	{
		public void ReadFrom(string fileName)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			// Create an XML reader for this file.
			using (XmlReader reader = XmlReader.Create(fileName, settings))
			{
				while (reader.Read())
				{
					if (reader.IsStartElement())
					{
						if (reader.IsEmptyElement)
							Console.WriteLine("<{0}/>", reader.Name);
						else
						{
							Console.Write("<{0}> ", reader.Name);
							reader.Read(); // Read the start tag.
							if (reader.IsStartElement())  // Handle nested elements.
								Console.Write("\r\n<{0}>", reader.Name);
							Console.WriteLine(reader.ReadString());  //Read the text content of the element.
						}
					}
				}
			}
		}
	}
}
