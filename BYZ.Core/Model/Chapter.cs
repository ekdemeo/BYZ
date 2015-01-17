using System.Collections.Generic;
using System.Xml.Serialization;

namespace BYZ.Core.Model
{
    [XmlRoot("C")]
    public class Chapter
    {
        public Chapter()
        {

        }

        public Chapter(int no)
        {
            No = no;
            Verses = new List<Verse>();
        }

        [XmlAttribute("N")]
        public int No { get; set; }

        public List<Verse> Verses { get; set; }
    }
}