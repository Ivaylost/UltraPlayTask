using System.Xml.Serialization;

namespace UltraPlayTask.Services.XmlModels
{
    [XmlRoot(ElementName = "XmlSports")]
	public class XmlSports
	{
		[XmlElement(ElementName = "Sport")]
		public XmlSport XmlSport { get; set; }
	}
}
