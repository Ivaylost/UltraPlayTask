using System.Collections.Generic;
using System.Xml.Serialization;

namespace UltraPlayTask.Services.XmlModels
{
	[XmlRoot(ElementName = "Sport")]
	public class XmlSport
	{
		[XmlElement(ElementName = "Event", IsNullable = true)]
		public List<XmlEvent> XmlEvents { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int ID { get; set; }
	}
}
