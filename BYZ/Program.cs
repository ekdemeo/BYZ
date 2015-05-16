using BYZ.Core;
using BYZ.Core.Model;
using BYZ.Data;
using BYZ.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BYZ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var reader = new JsonReader();
            var pol = reader.Read<Pol>("../../data/pol.json").ToList();
            var byz = reader.Read<Byz>("../../data/byz.json").ToList();
            var link = reader.Read<Link>("../../data/link.json");

            var translator = new Translator();
            var words = translator.Translate(pol, byz, link);

            var generator = new ModelGenerator();
            var book = generator.GenerateBook("Mathew", words);

            Bible bible = new Bible();
            bible.Books.Add(book);

            var xml = new XmlBibleSerializer();
            var path = "../../data/bible_generated.xml";

            if (File.Exists(path))
                File.Delete(path);

            xml.Serialize(path, bible);

            Console.WriteLine("done.");
        }
    }
}