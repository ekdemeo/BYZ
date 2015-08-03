using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BYZ.Core.Model;

namespace BYZ.Core.Converters
{
    public class ExpexBibleConverter
    {
        public IEnumerable<string> GetLines(Bible bible)
        {
            foreach (var book in bible.Books)
            {
                yield return string.Format(@"\renewcommand{{\chaptertitle}}{{{0}}}", book.Name);

                foreach (var chapter in book.Chapters)
                {
                    yield return string.Format(@"\begingl");
                    yield return string.Format(@"\lettrine[loversize=1,lraise=-1.3]{{{0} }}{{}}%", chapter.No);

                    yield return string.Format(@"\gla");
                    int verseNo = 1;
                    foreach (var verse in chapter.Verses)
                    {
                        yield return (verseNo++ > 1 ? @"{}" : "") + " " + string.Join(" ", verse.Words.Select(w => string.IsNullOrEmpty(w.Strong) ? @"{}" : w.Strong));
                    }

                    yield return string.Format(@"//");
                    yield return string.Format(@"\glb");

                    verseNo = 1;
                    foreach (var verse in chapter.Verses)
                    {
                        yield return (verseNo > 1 ? string.Format(@"\vs{{{0}}}", verseNo) : "") + " " + string.Join(" ", verse.Words.Select(GetFormattedString));
                        verseNo++;
                    }

                    yield return string.Format(@"//");
                    yield return string.Format(@"\endgl");
                }
            }
        }

        private string GetFormattedString(Word w)
        {
            switch (w.Underline)
            {
                case (int) Underline.Single:
                    return string.Format(@"\underline{{{0}}}", w.Pol);
                case (int)Underline.Double:
                    return string.Format(@"\doubleline{{{0}}}", w.Pol);
                default:
                    return w.Pol;
            }
        }
    }
}