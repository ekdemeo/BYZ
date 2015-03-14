using System.Collections.Generic;
using BYZ.Core;
using BYZ.Core.Model;
using NUnit.Framework;

namespace BYZ.Tests.Generator
{
    public class GenerateStructure : GeneratorTests
    {
        public GenerateStructure()
        {
            Words = new List<WordTranslation>()
            {
                new WordTranslation(40, 1, 1, "Zwój ksiêgi", "976", 1),
                new WordTranslation(40, 1, 1, "(o)", "", 0),
                new WordTranslation(40, 1, 1, "narodzinach", "1076", 0),
                new WordTranslation(40, 1, 1, "Jezusa", "2424", 0),
                new WordTranslation(40, 1, 2, "Abraham", "1", 0),
                new WordTranslation(40, 1, 2, "zrodzi³", "1080", 0),

                new WordTranslation(40, 12, 36, "nie", "3756", 0),
                new WordTranslation(40, 12, 36, "bêdzie", "1325", 2),
                new WordTranslation(40, 12, 36, "mu", "846", 0),
                new WordTranslation(40, 12, 36, "dany", "1325", 2),

                new WordTranslation(40, 12, 50, "bêdzie", "4160", 3),
                new WordTranslation(40, 12, 50, "czyni³", "4160", 3),

                new WordTranslation(40, 14, 16, "musz¹", "5532_2192", 4),
                new WordTranslation(40, 14, 16, "czyniæ", "4160", 0),
            };
        }

        [Test]
        public void GenerateChapters()
        {
            var book = GetBookTest();

            Assert.That(book.Chapters.Count, Is.EqualTo(3)); // 1,12,14
            Assert.AreEqual(book.Chapters[0].No, 1);
            Assert.AreEqual(book.Chapters[1].No, 12);
            Assert.AreEqual(book.Chapters[2].No, 14);
        }

        [Test]
        public void GenerateVerses()
        {
            var book = GetBookTest();

            var verses = book.Chapters[0].Verses;

            Assert.That(verses.Count, Is.EqualTo(2)); // 1,2
            Assert.AreEqual(verses[0].No, 1);
            Assert.AreEqual(verses[1].No, 2);
        }

        [Test]
        public void GenerateWords()
        {
            var book = GetBookTest();

            var words = book.Chapters[0].Verses[0].Words;

            Assert.That(words.Count, Is.EqualTo(4));
        }

        private Book GetBookTest()
        {
            var book = Generator.GenerateBook("Mathew", Words);
            return book;
        }
    }
}