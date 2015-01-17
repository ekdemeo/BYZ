using System.IO;
using System.Xml.Serialization;
using BYZ.Core.Model;

namespace BYZ.Core
{
    public class XmlBibleSerializer
    {
        public void Serialize(string fileName, Bible bible)
        {
            var serializer = new XmlSerializer(typeof(Bible));

            using (var stream = new FileStream(fileName, FileMode.CreateNew))
            {
                serializer.Serialize(stream, bible);
            }
        }
    }
}