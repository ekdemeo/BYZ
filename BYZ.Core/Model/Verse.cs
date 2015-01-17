using System.Collections.Generic;
using System.Xml.Serialization;

namespace BYZ.Core.Model
{
    [XmlRoot(ElementName = "V")]
    public class Verse
    {
        public Verse()
        {

        }

        public Verse(int no)
        {
            No = no;
            Words = new List<Word>();
        }

        [XmlAttribute("N")]
        public int No { get; set; }

        public List<Word> Words { get; set; }
    }
}