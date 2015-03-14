using System.Xml.Serialization;

namespace BYZ.Core.Model
{
    [XmlRoot("W")]
    public class Word
    {
        [XmlAttribute("T")]
        public string Pol { get; set; }

        [XmlAttribute("S")]
        public string Strong { get; set; }

        [XmlAttribute("G")]
        public int Underline { get; set; }

        [XmlIgnore]
        public int WordGroup { get; set; }
    }
}