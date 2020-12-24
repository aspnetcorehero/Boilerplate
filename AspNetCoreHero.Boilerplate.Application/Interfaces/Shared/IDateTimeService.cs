using System;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Shared
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}