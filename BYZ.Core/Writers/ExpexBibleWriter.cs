using System.IO;
using System.Xml.Serialization;
using BYZ.Core.Converters;
using BYZ.Core.Model;

namespace BYZ.Core.Writers
{
    public class ExpexBibleWriter : IBibleWriter
    {
        ExpexBibleConverter _converter = new ExpexBibleConverter();

        public void Convert(string fileName, Bible bible)
        {
            using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (var stream = new StreamWriter(file))
            {
                foreach (var line in _converter.GetLines(bible))
                {
                   stream.WriteLine(line);
                }
            }
        }
    }
}