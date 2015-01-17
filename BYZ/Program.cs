using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BYZ.Data;
using BYZ.Data.Infrastructure;

namespace BYZ
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new JsonReader();
            var pol = reader.Read<Pol>("../../../data/pol.json");
            var byz = reader.Read<Byz>("../../../data/byz.json");
            var link = reader.Read<Link>("../../../data/link.json");


            var result = from p in pol.Where(x => x.Verse < 30)
                         join l in link on p.Uid equals l.Pol
                         join b in byz.Where(x => x.Verse < 30) on l.Byz equals b.Uid
                         select new
                         {
                             Pol = p.Word,
                             Strong = b.Strong,
                             Byz = b.Word
                         };


            File.WriteAllLines("result.txt", result
                .Take(30)
                .Select(res => string.Format("{0} [{1} {2}]", res.Pol, res.Strong, res.Byz)),
                Encoding.UTF8);

            Console.WriteLine("done.");
            //Console.ReadKey();
        }
    }
}
