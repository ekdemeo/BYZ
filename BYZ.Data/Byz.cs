using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYZ.Data
{
    /* "uid" : 1,
		"book" : 40,
		"chapter" : 1,
		"verse" : 1,
		"no" : 1,
		"word_raw" : "βιβλος",
		"word" : "Βίβλος",
		"seg" : " ",
		"strong" : 976,
		"parsing" : "N-NSF"
    */
    public class Byz : WordBase
    {
        public Byz(int uid, string word, int strong)
        {
            Uid = uid;
            Word = word;
            Strong = strong;
        }

        public string WordRaw { get; set; }

        public string Seg { get; set; }

        public int Strong { get; set; }

        public string Parsing { get; set; }
    }
}
