using BYZ.Data;
using System.Collections.Generic;
using System.Linq;

namespace BYZ.Core
{
    public class Translator
    {
        public void AddLinksForNonTranslatedWords(List<Pol> pol,
            List<Byz> byz, List<Link> link)
        {
            byz.Add(new Byz(0, "", 0));

            foreach (var word in pol.Where(w => w.Word.First() == '(' && w.Word.Last() == ')'))
            {
                link.Add(new Link(word.Uid, 0));
            }
        }


        public IEnumerable<WordTranslation> Translate(IEnumerable<Pol> pol,
            IEnumerable<Byz> byz, IEnumerable<Link> link)
        {
            var result = from p in pol
                         join l in link on p.Uid equals l.Pol
                         join b in byz on l.Byz equals b.Uid
                         group b by p.Word
                             into g
                             let byzWords = g.ToList()
                             let polWord = g.Key
                             select new WordTranslation()
                             {
                                 Pol = polWord,
                                 Strong = byzWords[0].Strong > 0
                                 ? string.Join("_", byzWords.Select(x => x.Strong.ToString())) : null,
                                 Byz = string.Join(", ", byzWords.Select(x => x.Word.ToString()))
                             };
            return result;
        }
    }
}