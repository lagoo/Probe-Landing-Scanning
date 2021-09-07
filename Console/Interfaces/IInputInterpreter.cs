using Console.Entities;
using System.Collections.Generic;

namespace Console.Interfaces
{
    public interface IInputInterpreter
    {
        Position PlatformMaxPosition { get; }
        IEnumerable<ProbeParams> ProbesParamns { get; }
    }
}
