using System.Collections.Generic;
using System.Xml.Serialization;

namespace UltraPlayTask.Services.XmlModels
{
    [XmlRoot(ElementName = "Event")]
	public class XmlEvent
	{
		[XmlElement(ElementName = "Match", IsNullable = true)]
		public List<XmlMatch> XmlMatches { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int ID { get; set; }

		[XmlAttribute(AttributeName = "IsLive")]
		public bool IsLive { get; set; }

		[XmlAttribute(AttributeName = "CategoryID")]
		public int CategoryID { get; set; }
	}
}
