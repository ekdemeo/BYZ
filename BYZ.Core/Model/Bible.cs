using System.Collections.Generic;

namespace BYZ.Core.Model
{
    public class Bible
    {
        public Bible()
        {
            Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
    }
}