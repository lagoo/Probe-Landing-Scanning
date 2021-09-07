using Console.Entities;
using Console.Interfaces;

namespace Console.Implementations
{
    public class MoveOnDirectionCommand : IProbeCommand
    {
        public void Execute(Probe probe)
        {
            probe.Move();
        }
    }
}
