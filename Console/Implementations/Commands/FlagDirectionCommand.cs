using Console.Entities;
using Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Implementations
{
    public class FlagDirectionCommand : IProbeCommand
    {
        public void Execute(Probe probe)
        {
            probe.MarkFlag();
        }
    }
}
