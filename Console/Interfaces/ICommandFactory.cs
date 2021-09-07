namespace Console.Interfaces
{
    public interface ICommandFactory
    {
        IProbeCommand Create(char action);
    }
}
