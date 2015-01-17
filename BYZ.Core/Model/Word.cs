namespace BYZ.Core.Model
{
    public enum Underline
    {
        Single,
        Double
    }

    public class Word
    {
        public string Pol { get; set; }

        public string Byz { get; set; }

        public string Strong { get; set; }

        public Underline Underline { get; set; }
    }
}