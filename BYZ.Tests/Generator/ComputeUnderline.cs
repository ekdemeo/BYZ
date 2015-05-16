using BYZ.Core;
using BYZ.Core.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BYZ.Tests.Generator
{
    public class ComputeUnderline : GeneratorTests
    {
        private Book book;

        public ComputeUnderline()
        {
            Words = new List<WordTranslation>()
            {
                new WordTranslation(40, 1, 1, "a1", "976", 1),
                new WordTranslation(40, 1, 1, "b1", "2424", 2),
                new WordTranslation(40, 1, 1, "a2", "976", 1),
                new WordTranslation(40, 1, 1, "b2", "2424", 2),
                new WordTranslation(40, 1, 1, "b3", "2424", 2),
                new WordTranslation(40, 1, 2, "c1", "4212", 3),
                new WordTranslation(40, 1, 2, "b3", "3323", 4),
                new WordTranslation(40, 1, 2, "c2", "4212", 3),
            };
        }

        [Test]
        public void ShouldComputeSingleAndDoubleUnderline()
        {
            book = Generator.GenerateBook("test", Words);

            var words = book.Chapters.First().Verses[0].Words;

            foreach (var word in words)
            {
                if (word.WordGroup == 1)
                    Assert.AreEqual(word.Underline, 1);
                if (word.WordGroup == 2)
                    Assert.AreEqual(word.Underline, 2);
            }

            words = book.Chapters.First().Verses[1].Words;

            foreach (var word in words)
            {
                if (word.WordGroup == 3)
                    Assert.AreEqual(word.Underline, 1);
                if (word.WordGroup == 4)
                    Assert.AreEqual(word.Underline, 2);
            }
        }
    }
}