using Console.Interfaces;

namespace Console.Implementations
{
    public class MoveOnDirectionCommand : IProbeCommand
    {
        public void DoAction(Probe probe)
        {
            probe.Move();
        }
    }
}
