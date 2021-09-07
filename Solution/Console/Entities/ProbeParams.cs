using Console.Enums;
using Console.Interfaces;
using System;
using System.Collections.Generic;

namespace Console.Entities
{
    public class ProbeParams
    {
        public Position InitialPosition { get; }
        public WindroseEnum Direction { get; }

        private readonly List<IProbeCommand> _commands;
        public IEnumerable<IProbeCommand> Commands => _commands;

        public ProbeParams(Position inital, char direction)
        {
            InitialPosition = inital;
            Direction = direction switch
            {
                'N' => WindroseEnum.N,
                'E' => WindroseEnum.E,
                'S' => WindroseEnum.S,
                'W' => WindroseEnum.W,
                _ => throw new NotImplementedException("Não foi possivel converter valor para as rosa dos ventos!!"),
            };
            _commands = new List<IProbeCommand>();
        }

        public void Add(IProbeCommand probeCommand) => _commands.Add(probeCommand);
    }
}
