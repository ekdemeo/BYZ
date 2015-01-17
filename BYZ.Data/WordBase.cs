namespace BYZ.Data
{
    public abstract class WordBase
    {
        public int Uid { get; set; }

        public int Book { get; set; }

        public int Chapter { get; set; }

        public int Verse { get; set; }

        public int No { get; set; }

        public string Word { get; set; }
    }
}