using Console.Entities;
using Console.Interfaces;

namespace Console.Implementations
{
    public class ChangeDirectionCommand : IProbeCommand
    {
        private readonly int value;

        public ChangeDirectionCommand(char direction)
        {
            value = direction == 'L' ? -1 : 1;
        }

        public void Execute(Probe probe)
        {
            probe.ChangeDirection(value);
        }
    }
}
