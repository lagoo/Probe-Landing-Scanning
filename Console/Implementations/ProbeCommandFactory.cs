using Console.Interfaces;
using System;

namespace Console.Implementations
{
    public class ProbeCommandFactory : ICommandFactory
    {
        public IProbeCommand Create(char action)
        {
            IProbeCommand command = null;

            if (action == 'L' || action == 'R')
                command = new ChangeDirectionCommand(action);

            if (action == 'M')
                command = new MoveOnDirectionCommand();

            if (action == 'F')
                command = new FlagDirectionCommand();

            if (command == null)
                throw new NotImplementedException("Não foi possivel converter ação informada!!");

            return command;
        }
    }
}
