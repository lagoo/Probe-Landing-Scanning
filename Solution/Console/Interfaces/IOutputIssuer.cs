using Console.Entities;
using System.Collections.Generic;

namespace Console.Interfaces
{
    public interface IOutputIssuer
    {
        void Print(IEnumerable<Probe> probes);
    }
}
