using Console.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Console
{
    public class Probe
    {
        private readonly Position min = new();
        private readonly Position max;
        private int _direction;
        private readonly List<IProbeCommand> _commands;

        public int XAsis { get; private set; }
        public int YAsis { get; private set; }
        public WindroseEnum Direction => (WindroseEnum)_direction;
        public IReadOnlyList<IProbeCommand> Commands => _commands;


        public Probe(ProbeParams probeParams, Position max)
        {
            this.max = max;

            XAsis = probeParams.InitialPosition.xaxis;
            YAsis = probeParams.InitialPosition.yaxis;

            _direction = (int)probeParams.Direction;

            _commands = probeParams.Commands.ToList();
        }

        public void Move()
        {
            switch (Direction)
            {
                case WindroseEnum.N:
                    YAsis = (YAsis + 1 > max.yaxis) ? max.yaxis : YAsis+1;
                    break;
                case WindroseEnum.E:
                    XAsis = (XAsis + 1 > max.xaxis) ? max.xaxis : XAsis+1;
                    break;
                case WindroseEnum.S:
                    YAsis = (YAsis - 1 < min.yaxis) ? min.yaxis : YAsis-1;
                    break;
                case WindroseEnum.W:
                    XAsis = (XAsis - 1 < min.xaxis) ? min.xaxis : XAsis-1;
                    break;
                default:
                    break;
            }
        }

        public void ChangeDirection(int value)
        {
            _direction += value;

            if (_direction < 1)
                _direction = 4;

            if (_direction > 4)
                _direction = 1;
        }

        public void ExecuteCommands()
        {
            _commands.ForEach(item => item.DoAction(this));
        }

        public override string ToString()
        {
            return $"{XAsis} {YAsis} {Direction}";
        }
    }
}
