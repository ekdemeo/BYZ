using BYZ.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace BYZ.Core
{
    public class ModelGenerator
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
                    Pol = word.Pol,
                    WordGroup = word.WordGroup
                });
            }

            foreach (var verse in book.Chapters.SelectMany(x => x.Verses))
            {
                ComputeUnderlines(verse);
            }

            return book;
        }

        private void ComputeUnderlines(Verse verse)
        {
            var result = from w in verse.Words
                         where w.WordGroup > 0
                         group w by w.WordGroup
                             into g
                             orderby g.Key ascending
                             select g;

            var currentUnderline = 0;

            foreach (var wordGroup in result)
            {
                foreach (var word in wordGroup.ToList())
                {
                    word.Underline = currentUnderline;
                }

                currentUnderline = (currentUnderline + 1) % 2;
            }
        }
    }
}