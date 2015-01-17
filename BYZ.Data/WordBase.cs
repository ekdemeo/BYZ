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

        public override bool Equals(object obj)
        {
            var wordBase = obj as WordBase;
            return wordBase.Book == this.Book
                   && wordBase.Chapter == this.Chapter
                   && wordBase.Verse == this.Verse
                   && wordBase.Word == this.Word;
        }
    }
}