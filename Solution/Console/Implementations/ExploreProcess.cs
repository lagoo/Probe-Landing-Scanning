using Console.Entities;
using Console.Interfaces;
using System.Collections.Generic;

namespace Console.Implementations
{
    public class ExploreProcess : IProcess
    {
        private readonly IInputInterpreter input;
        private readonly IOutputIssuer output;

        public ExploreProcess(IInputInterpreter input, IOutputIssuer output)
        {
            this.input = input;
            this.output = output;
        }

        public void Execute()
        {
            List<Probe> probes = new();

            foreach (var probeParamns in input.ProbesParamns)
            {
                probes.Add(new Probe(probeParamns.InitialPosition, input.PlatformMaxPosition, probeParamns.Direction, probeParamns.Commands));
            }

            probes.ForEach(item => item.ExecuteCommands());

            output.Print(probes);
        }
    }
}
