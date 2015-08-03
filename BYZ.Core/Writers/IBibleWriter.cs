using BYZ.Core.Model;

namespace BYZ.Core.Converters
{
    public interface IBibleWriter
    {
        void Convert(string fileName, Bible bible);

    }
}