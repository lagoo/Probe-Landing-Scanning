using Console.Interfaces;
using System.IO;

namespace Console.Implementations
{
    public class FileReader : IDataReader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
