using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using System;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}