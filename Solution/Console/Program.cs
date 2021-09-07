using Console.Implementations;
using Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var input = host.Services.GetService<IInputInterpreter>();
            var output = host.Services.GetService<IOutputIssuer>();

            var probes = new List<Probe>();

            foreach (var probe in input.Probes)
            {
                probes.Add(new Probe(probe, input.PlatformMaxPosition));
            }

            probes.ForEach(item => item.ExecuteCommands());

            output.Print(probes);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IInputInterpreter, FileInputInterpreter>();
                    services.AddScoped<IOutputIssuer, FileOutputIssuer>();
                    //services.AddScoped<IOutputIssuer, ConsoleOutputIssuer>();
                });
    }
}
