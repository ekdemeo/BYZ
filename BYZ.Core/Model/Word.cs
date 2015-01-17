using System.Xml.Serialization;

namespace BYZ.Core.Model
{
    public enum Underline
    {
        Single,
        Double
    }

    [XmlRoot("W")]
    public class Word
    {
        [XmlAttribute("T")]
        public string Pol { get; set; }

        [XmlAttribute("S")]
        public string Strong { get; set; }

        //public Underline Underline { get; set; }
    }
}