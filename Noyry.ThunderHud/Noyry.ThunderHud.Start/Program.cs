using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Noyry.ThunderHud.Application;
using Noyry.ThunderHud.Application.Air;
using Noyry.ThunderHud.Infrastructure.Game;

namespace Noyry.ThunderHud.Start
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting...");

            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                    .AddTransient<IAircraftIndicatorService, AircraftIndicatorsService>()
                    .AddTransient<IAircraftStateService, AircraftStateService>()

                    .AddSingleton<HttpClient>()

                    .ConfigureConsoleRender()

                    .AddSingleton<GameReaderApp>();
                });

            builder.ConfigureLogging(logging => logging.AddConsole());

            var app = builder.Build();
            CancellationTokenSource cts = new();
            await app.Services.GetRequiredService<GameReaderApp>().StartAsync(cts.Token);
            
            Console.WriteLine("Finishing...");
        }
    }
}
