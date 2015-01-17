using System.Collections.Generic;

namespace BYZ.Core.Model
{
    public class Book
    {
        public Book()
        {
            Chapters = new List<Chapter>();
        }

        public string Name { get; set; }

        public List<Chapter> Chapters { get; set; }
    }
}