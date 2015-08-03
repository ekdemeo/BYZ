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
using BYZ.Core.Converters;
using BYZ.Core.Writers;

namespace BYZ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var outputPath = "../../output/";

            var reader = new JsonReader();
            var pol = reader.Read<Pol>(outputPath + "pol.json").ToList();
            var byz = reader.Read<Byz>(outputPath + "byz.json").ToList();
            var link = reader.Read<Link>(outputPath + "link.json");

            var translator = new Translator();
            var words = translator.Translate(pol, byz, link);

            var generator = new ModelBuilder();
            var book = generator.GenerateBook("Mathew", words);

            Bible bible = new Bible();
            bible.Books.Add(book);

            //var path = outputPath + "bible.xml";
            //var xml = new XmlBibleWriter();
          

            //if (File.Exists(path))
            //    File.Delete(path);

            //xml.Convert(path, bible);

            var path = outputPath + "bible_content.tex";
            var expex = new ExpexBibleWriter();
            expex.Convert(path, bible);

            Console.WriteLine("done.");
        }
    }
}