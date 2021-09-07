using Console.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Console.Implementations
{
    public class FileInputInterpreter : IInputInterpreter
    {
        public const string fileName = "entrada.txt";

        private Position _position; 
        public Position PlatformMaxPosition => _position;

        private List<ProbeParams> _probeParams = new();
        public IEnumerable<ProbeParams> Probes => _probeParams;


        public FileInputInterpreter()
        {
            var allLines = File.ReadAllLines(fileName);

            if (allLines.Length < 3)
                throw new Exception("Arquivo não contem dados o suficiente!!!");

            FillPlatValue(allLines);
            FillProbeValues(allLines);
        }

        private void FillProbeValues(string[] allLines)
        {
            var plat = allLines[0].Replace(" ", "").ToCharArray();

            _position = new Position(Convert.ToInt32(plat[0].ToString()), Convert.ToInt32(plat[1].ToString()));
        }

        private void FillPlatValue(string[] allLines)
        {
            for (int i = 1; i < allLines.Length ; i += 2)
            {
                var posValue = allLines[i].Replace(" ", "").ToCharArray();

                var probe = new ProbeParams(new Position(Convert.ToInt32(posValue[0].ToString()), Convert.ToInt32(posValue[1].ToString())), posValue[2]);

                var commands = allLines[i + 1].ToCharArray();

                foreach (var cmm in commands)
                {
                    if (cmm == 'L' || cmm == 'R')
                        probe.Add(new ChangeDirectionCommand(cmm));

                    if (cmm == 'M')
                        probe.Add(new MoveOnDirectionCommand());
                }

                _probeParams.Add(probe);
            }
        }
    }
}
