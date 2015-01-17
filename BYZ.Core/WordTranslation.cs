using System;

namespace BYZ.Core
{
    public class WordTranslation
    {
        public WordTranslation()
        {

        }

        public WordTranslation(int book, int chapter, int verse, string pol, string strong, int wordGroup)
        {
            Strong = strong;
            Pol = pol;
            WordGroup = wordGroup;
            Verse = verse;
            Chapter = chapter;
            Book = book;
        }

        public int Book { get; set; }

        public int Chapter { get; set; }

        public int Verse { get; set; }

        public int No { get; set; }

        public string Pol { get; set; }

        public string Byz { get; set; }

        public string Strong { get; set; }

        public int WordGroup { get; set; }
    }
}