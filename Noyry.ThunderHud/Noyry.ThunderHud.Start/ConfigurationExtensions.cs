using Microsoft.Extensions.DependencyInjection;
using Noyry.ThunderHud.Application.Interface;
using Noyry.ThunderHud.Domain.Model.Air;
using Noyry.ThunderHud.UI;
using Noyry.ThunderHud.UI.ConsoleRender;
using System.Collections.ObjectModel;

namespace Noyry.ThunderHud.Start
{
    internal static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureConsoleRender(this IServiceCollection serviceCollection)
        {
            RenderObject<Aircraft> speed = new((aircraft) => $"Speed: {aircraft.State.SpeedKmPerHour} km\\h");
            RenderObject<Aircraft> timestamp = new((aircraft) => $"Timestamp: {DateTime.Now.ToString("HH:mm:ss:fff")}");
            List<RenderObject<Aircraft>> renderObjectsList = new() { speed, timestamp };
            ReadOnlyCollection<RenderObject<Aircraft>> renderObjects = new(renderObjectsList);

            ConsoleRendererConfig<Aircraft> config = new (renderObjects);

            serviceCollection
                .AddSingleton(config)
                .AddSingleton<IRenderer<Aircraft>, ConsoleRenderer<Aircraft>>();

            return serviceCollection;
        }
    }
}
