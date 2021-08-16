using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using UltraPlayTask.Services.Updater.Contracts;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater
{
    public class ReadInput : IReadInput
    {
        private readonly WebClient webClient;        

        public ReadInput()
        {
            this.webClient = new WebClient();
        }

        public XmlSports Read()
        {
            Stream stream = this.webClient.OpenRead(Constants.UltraPlayConection);
            var xml = XDocument.Load(new StreamReader(stream, Encoding.UTF8)).ToString();
            stream.Close();

            StringReader reader = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));
            var result = (XmlSports)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }
    }
}
