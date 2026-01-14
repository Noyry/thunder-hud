using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Noyry.ThunderHud.Application;
using Noyry.ThunderHud.Application.Aircraft;
using Noyry.ThunderHud.Infrastructure.Game;

namespace Noyry.ThunderHud.Start
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                    .AddTransient<IAircraftIndicatorService, AircraftIndicatorsService>()
                    .AddTransient<IAircraftStateService, AircraftStateService>();

                    services.AddSingleton<HttpClient>();

                    services.AddSingleton<GameReaderApp>();
                });
            var app = builder.Build();
            CancellationTokenSource cts = new();
            await app.Services.GetRequiredService<GameReaderApp>().StartAsync(cts.Token);
            Console.WriteLine("Done!");
        }
    }
}
