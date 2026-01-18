using Noyry.ThunderHud.Application.UserInterface;
using Noyry.ThunderHud.Domain.Model.Abstract;

namespace Noyry.ThunderHud.UI.ConsoleRender
{
    public class ConsoleRenderer<T> : IRenderer<T> where T : IVehicle
    {
        public ConsoleRenderer(ConsoleRendererConfig<T> config)
        {
            _config = config;
        }

        private readonly ConsoleRendererConfig<T> _config;

        public Task Render(T vehicle, CancellationToken cancellationToken)
        {
            int bufferWidth = Console.BufferWidth;
            
            Console.SetCursorPosition(0, 0);
            foreach (var renderObj in _config.GetRenderObjects())
            {
                string value = renderObj.GetText(vehicle);
                value = value.PadRight(bufferWidth);
                Console.WriteLine(value);
            }

            while (Console.CursorTop < Console.BufferHeight - 1)
            {
                Console.WriteLine();
            }

            return Task.CompletedTask;
        }
    }
}
