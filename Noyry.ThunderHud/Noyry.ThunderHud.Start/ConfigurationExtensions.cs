using Microsoft.Extensions.DependencyInjection;
using Noyry.ThunderHud.Application.UserInterface;
using Noyry.ThunderHud.Domain.Model.Air;
using Noyry.ThunderHud.UI;
using Noyry.ThunderHud.UI.ConsoleRender;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;

namespace Noyry.ThunderHud.Start
{
    internal static class ConfigurationExtensions
    {
        private static string GetFuelLeft(Aircraft aircraft)
        {
            const int minutesMaxValue = 999;

            string minutesResult = "XX";
            string secondsResult = "XX";

            var fuelLeftProperty = aircraft?.CalculatedInfo?.FuelLeft;
            if (fuelLeftProperty.HasValue)
            {
                var fuelLeft = fuelLeftProperty.Value;
                double totalMinutes = fuelLeft.TotalMinutes;
                if (totalMinutes > minutesMaxValue)
                {
                    minutesResult = "999";
                    secondsResult = "59";
                }
                else 
                { 
                    minutesResult = Convert.ToInt32(totalMinutes).ToString();
                    secondsResult = fuelLeft.Seconds.ToString();
                }
            }

            string result = $"Fuel: {minutesResult}:{secondsResult}";
            return result;
        }

        public static IServiceCollection ConfigureConsoleRender(this IServiceCollection serviceCollection)
        {
            RenderObject<Aircraft> name = new((aircraft) => $"Name: {aircraft.Name}");
            RenderObject<Aircraft> speed = new((aircraft) => $"IAS: {aircraft.State.IndicatedSpeedKmPerHour} km\\h");
            RenderObject<Aircraft> fuel = new(GetFuelLeft);
            RenderObject<Aircraft> height = new((aircraft) => $"Height: {aircraft.State.AbsoluteHeightMeters} m");
            RenderObject<Aircraft> timestamp = new((aircraft) => $"Timestamp: {DateTime.Now:HH:mm:ss:fff}");
            
            List<RenderObject<Aircraft>> renderObjectsList = new() { name, speed, fuel, height, timestamp };
            ReadOnlyCollection<RenderObject<Aircraft>> renderObjects = new(renderObjectsList);

            ConsoleRendererConfig<Aircraft> config = new (renderObjects);

            serviceCollection
                .AddSingleton(config)
                .AddSingleton<IRenderer<Aircraft>, ConsoleRenderer<Aircraft>>();

            return serviceCollection;
        }
    }
}
