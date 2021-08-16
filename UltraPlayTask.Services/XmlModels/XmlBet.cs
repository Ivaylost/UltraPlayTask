using System.Collections.Generic;
using System.Xml.Serialization;

namespace UltraPlayTask.Services.XmlModels
{
    [XmlRoot(ElementName = "Bet")]
	public class XmlBet
	{
		[XmlElement(ElementName = "Odd", IsNullable = true)]
		public List<XmlOdd> XmlOdds { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int ID { get; set; }

		[XmlAttribute(AttributeName = "IsLive")]
		public bool IsLive { get; set; }
	}
}
