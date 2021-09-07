using Console.Implementations;
using Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var process = host.Services.GetService<IProcess>();

            process.Execute();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IProcess, ExploreProcess>();

                    services.AddScoped<IDataReader, FileReader>();
                    services.AddScoped<ICommandFactory, ProbeCommandFactory>();

                    services.AddScoped<IInputInterpreter, FileInputInterpreter>();

                    services.AddScoped<IOutputIssuer, FileOutputIssuer>();
                    //services.AddScoped<IOutputIssuer, ConsoleOutputIssuer>();
                });
    }
}
