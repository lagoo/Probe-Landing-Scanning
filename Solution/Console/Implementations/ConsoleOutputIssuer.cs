using Console.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Console.Implementations
{
    public class ConsoleOutputIssuer : IOutputIssuer
    {
        public void Print(IEnumerable<Probe> probes)
        {
            foreach (var item in probes)
            {
               System.Console.WriteLine(item.ToString());
            }
        }
    }
}
