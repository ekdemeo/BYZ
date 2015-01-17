

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BYZ.Core.Model;


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
                });
            }


            return book;
        }
    }
}