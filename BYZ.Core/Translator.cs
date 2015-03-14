using BYZ.Data;
using System.Collections.Generic;
using System.Linq;

namespace BYZ.Core
{
    public class Translator
    {
        public List<WordTranslation> Translate(List<Pol> pol, List<Byz> byz, List<Link> link)
        {
            AddLinksForNonTranslatedWords(pol, byz, link);

            var result = from p in pol
                         join l in link on p.Uid equals l.Pol
                         join b in byz on l.Byz equals b.Uid
                         group b by new { p.Word, p.Book, p.Chapter, p.Verse, p.No, p.WordGroup }
                             into g
                             let byzWords = g.ToList()
                             let word = g.Key.Word
                             let chapter = g.Key.Chapter
                             let verse = g.Key.Verse
                             let book = g.Key.Book
                             let no = g.Key.No
                             let wordGroup = g.Key.WordGroup
                             select new WordTranslation()
                             {
                                 Pol = word,
                                 Chapter = chapter,
                                 Verse = verse,
                                 Book = book,
                                 WordGroup = wordGroup,
                                 Strong = byzWords[0].Strong > 0
                                 ? string.Join("_", byzWords.Select(x => x.Strong.ToString()).Distinct()) : null,
                                 Byz = string.Join(", ", byzWords.Select(x => x.Word.ToString()).Distinct())
                             };
            return result
                .OrderBy(x => x.Book)
                .ThenBy(x => x.Chapter)
                .ThenBy(x => x.Verse)
                .ThenBy(x => x.No)
                .ToList();
        }

        private void AddLinksForNonTranslatedWords(List<Pol> pol, List<Byz> byz, List<Link> link)
        {
            byz.Add(new Byz(0, "", 0));

            foreach (var word in pol.Where(w => !string.IsNullOrWhiteSpace(w.Word)
                && w.Word.First() == '(' && w.Word.Last() == ')'))
            {
                link.Add(new Link(word.Uid, 0));
            }
        }
    }
}