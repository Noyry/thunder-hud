namespace Noyry.ThunderHud.Application.Common
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetTime() => DateTimeOffset.Now;
    }
}
