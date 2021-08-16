using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace UltraPlayTask.Services.XmlModels
{
    [XmlRoot(ElementName = "Match")]
	public class XmlMatch
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int ID { get; set; }

		[XmlAttribute(AttributeName = "StartDate")]
		public DateTime StartDate { get; set; }

		[XmlAttribute(AttributeName = "MatchType")]
		public string MatchType { get; set; }

		[XmlElement(ElementName = "Bet", IsNullable = true)]
		public List<XmlBet> XmlBets { get; set; }
	}
}
