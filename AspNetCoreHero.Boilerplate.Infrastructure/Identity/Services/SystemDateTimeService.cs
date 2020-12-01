using AspNetCoreHero.Boilerplate.Application.Interfaces;
using System;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Identity.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
