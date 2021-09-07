using Console.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Console.Implementations
{
    public class FileOutputIssuer : IOutputIssuer
    {
        public const string fileName = "saida.txt";

        public void Print(IEnumerable<Probe> probes)
        {
            using StreamWriter sw = new(fileName, false, Encoding.UTF8, 65536);

            foreach (var item in probes)
            {
                sw.WriteLine(item.ToString());
            }
        }
    }
}
