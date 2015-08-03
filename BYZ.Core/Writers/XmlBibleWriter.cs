using System.IO;
using System.Xml.Serialization;
using BYZ.Core.Model;

namespace BYZ.Core.Converters
{
    public class XmlBibleWriter : IBibleWriter
    {
        public void Convert(string fileName, Bible bible)
        {
            var serializer = new XmlSerializer(typeof(Bible));

            using (var stream = new FileStream(fileName, FileMode.CreateNew))
            {
                serializer.Serialize(stream, bible);
            }
        }
    }
}