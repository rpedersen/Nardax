using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nardax.Serialization
{
    public class BinarySerializer<T> : ISerializer<T, byte[]>
    {
        public byte[] Serialize(T value)
        {
            using (var stream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, value);
                return stream.ToArray();
            }
        }

        public T Deserialize(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryFormatter = new BinaryFormatter();
                memoryStream.Position = 0;
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
