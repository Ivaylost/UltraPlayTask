using System.Xml.Serialization;

namespace UltraPlayTask.Services.XmlModels
{
    [XmlRoot(ElementName = "Odd")]
	public class XmlOdd
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "ID")]
		public int ID { get; set; }

		[XmlAttribute(AttributeName = "Value")]
		public double Value { get; set; }

		[XmlAttribute(AttributeName = "SpecialBetValue")]
		public string SpecialBetValue { get; set; }
	}
}
