namespace AspNetCoreHero.Boilerplate.Application.DTOs.Settings
{
    public class CacheSettings
    {
        public int AbsoluteExpirationInHours { get; set; }
        public int SlidingExpirationInMinutes { get; set; }
    }
}