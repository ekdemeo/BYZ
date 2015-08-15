using BYZ.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace BYZ.Core
{
    public class ModelBuilder
    {
        public Book GenerateBook(string name, List<WordTranslation> words)
        {
            var book = new Book();
            var currentChapter = new Chapter(1);
            var currentVerse = new Verse(1);

            book.Chapters.Add(currentChapter);
            currentChapter.Verses.Add(currentVerse);

            foreach (var word in words)
            {
                if (word.Chapter != currentChapter.No)
                {
                    currentChapter = new Chapter(word.Chapter);
                    book.Chapters.Add(currentChapter);
                }

                if (word.Verse != currentVerse.No)
                {
                    currentVerse = new Verse(word.Verse);
                    currentChapter.Verses.Add(currentVerse);
                }

                currentVerse.Words.Add(new Word()
                {
                    Strong = word.Strong,
                    Pol = word.SegL.Trim() + word.Pol + AddSpaceBeforeDashIfExists(word.SegR.Trim()),
                    WordGroup = word.WordGroup,
                    IsNonBreakable = CheckIsNonBreakable(word)
                });
            }

            foreach (var verse in book.Chapters.SelectMany(x => x.Verses))
            {
                ComputeUnderlines(verse);
            }

            return book;
        }

        private int CheckIsNonBreakable(WordTranslation word)
        {
            return (word.Pol.Length == 1 || word.Pol.Last() == '–') ? 1 : 0;
        }

        private string AddConnectorIfOneChar(string word)
        {
            word = word.Trim();
            return word.Length == 1 ? word + "~" : word;
        }

        private string AddSpaceBeforeDashIfExists(string word)
        {
            return word.Length > 0 && word[0] == '–' ? " " + word : word;
        }


        private void ComputeUnderlines(Verse verse)
        {
            var result = from w in verse.Words
                         where w.WordGroup > 0
                         group w by w.WordGroup
                             into g
                             orderby g.Key ascending
                             select g;

            var currentUnderline = Underline.Single;

            foreach (var wordGroup in result)
            {
                foreach (var word in wordGroup.ToList())
                {
                    word.Underline = (int)currentUnderline;
                }

                currentUnderline = currentUnderline == Underline.Single ? Underline.Double : Underline.Single;
            }
        }
    }
}