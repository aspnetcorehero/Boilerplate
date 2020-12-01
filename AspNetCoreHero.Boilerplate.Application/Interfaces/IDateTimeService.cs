using System;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
