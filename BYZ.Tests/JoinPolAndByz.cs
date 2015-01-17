using BYZ.Core;
using BYZ.Data;
using NUnit.Framework;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace BYZ.Tests
{
    public class JoinPolAndByz
    {
        private readonly Translator _converter;

        public JoinPolAndByz()
        {
            _converter = new Translator();
        }

        [Test]
        public void JoinOnePolToOneByz()
        {
            // Mt 1:1
            var pol = new List<Pol>()
            {
                new Pol(1, "Zwój księgi"),
                new Pol(2, "(o)"),
                new Pol(3, "narodzinach"),
            };

            var byz = new List<Byz>()
            {
                new Byz(1, "βιβλος", 976),
                new Byz(2, "γενεσεως", 1078)
            };

            var link = new List<Link>()
            {
                new Link(1, 1),
                new Link(3, 2)
            };

            var words = _converter.Translate(pol, byz, link).ToList();

            AssertContainsWord(words, "Zwój księgi", "976");
            AssertContainsWord(words, "narodzinach", "1078");
        }

        [Test]
        public void JoinOnePolToManyByz()
        {
            var pol = new List<Pol>()
            {
                new Pol(1, "muszą"),
            };

            var byz = new List<Byz>()
            {
                new Byz(1, "χρεία", 5532),
                new Byz(2, "ἔχω", 2192)
            };

            var link = new List<Link>()
            {
                new Link(1, 1),
                new Link(1, 2)
            };

            var words = _converter.Translate(pol, byz, link).ToList();

            AssertContainsWord(words, "muszą", "5532_2192");
        }

        [Ignore("Not needed - MP supports grouping feature")]
        public void JoinManyPolToOneByz()
        {
            // Mt 4:10
            var pol = new List<Pol>()
            {
                new Pol(1, "będziesz"),
                new Pol(2, "oddawał"),
                new Pol(3, "pokłon"),
            };

            var byz = new List<Byz>()
            {
                new Byz(1, "προσκυνέω", 4352),
            };

            var link = new List<Link>()
            {
                new Link(1, 1),
                new Link(2, 1),
                new Link(3, 1)
            };

            var words = _converter.Translate(pol, byz, link).ToList();

            AssertContainsWord(words, "będziesz oddawał pokłon", "4352");
        }

        [Test]
        public void JoinManyPolSeperatedToOneByz()
        {
            // Mt 12:39
            var pol = new List<Pol>()
            {
                new Pol(1, "znak"),
                new Pol(2, "nie"),
                new Pol(3, "będzie"),
                new Pol(4, "mu"),
                new Pol(5, "dany"),
            };

            var byz = new List<Byz>()
            {
                new Byz(1, "σημεῖον", 4592),
                new Byz(2, "οὐ", 3756),
                new Byz(3, "δίδωμι", 1325),
                new Byz(4, "αὐτός", 846),
            };

            var link = new List<Link>()
            {
                new Link(1, 1),
                new Link(2, 2),
                new Link(3, 3),
                new Link(4, 4),
                new Link(5, 3)
            };


            var words = _converter.Translate(pol, byz, link).ToList();

            AssertContainsWord(words, "będzie", "1325");
            AssertContainsWord(words, "dany", "1325");
        }

        [Test]
        public void DoNotOmitUnlinkedWords()
        {
            // Mt 1:1
            var pol = new List<Pol>()
            {
                new Pol(1, "Zwój księgi"),
                new Pol(2, "(o)"),
                new Pol(3, "narodzinach"),
            };

            var byz = new List<Byz>()
            {
                new Byz(1, "βιβλος", 976),
                new Byz(2, "γενεσεως", 1078)
            };

            var link = new List<Link>()
            {
                new Link(1, 1),
                new Link(3, 2)
            };

            _converter.AddLinksForNonTranslatedWords(pol, byz, link);
            var words = _converter.Translate(pol, byz, link).ToList();

            AssertContainsWord(words, "Zwój księgi", "976");
            AssertContainsWord(words, "(o)", null);
            AssertContainsWord(words, "narodzinach", "1078");
        }

        private void AssertContainsWord(List<WordTranslation> words, string polWord, string strong)
        {
            Assert.That(words.FirstOrDefault(x => x.Strong == strong && x.Pol == polWord),
          Is.Not.Null);
        }
    }
}