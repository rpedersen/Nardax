using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Nardax.Serialization
{
    public class XmlSerializer<T> : ISerializer<T, string>
    {
        public string Serialize(T value)
        {
            using (var stream = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof(T));
                var xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, value);
                var xml = new UTF8Encoding().GetString(stream.ToArray());
                return xml;
            }
        }

        public T Deserialize(string value)
        {
            var bytes = new UTF8Encoding().GetBytes(value);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var obj = (T)new XmlSerializer(typeof(T)).Deserialize(memoryStream);
                return obj;
            }
        }
    }
}
