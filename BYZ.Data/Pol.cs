using System.Diagnostics;

namespace BYZ.Data
{
    /*
     * "uid" : 1,
       "user" : 1,
       "time" : 1411925272,
       "book" : 40,
       "chapter" : 1,
       "verse" : 1,
       "no" : 10,
       "word_group" : 1,
       "word" : "Zwój księgi",
       "seg_l" : "",
       "seg_r" : " "
     */

    [DebuggerDisplay("{SegL}{Word}{SegR} {Book} {Chapter}:{Verse}")]
    public class Pol : WordBase
    {
        public Pol(int uid, string word)
        {
            Uid = uid;
            Word = word;
        }

        public int WordGroup { get; set; }

        public string SegL { get; set; }

        public string SegR { get; set; }
    }
}