using AspNetCoreHero.Abstractions.Domain;
using System;

namespace AspNetCoreHero.Boilerplate.Domain.Common
{
    public class AuditLog : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public string Service { get; set; }
        public string Action { get; set; }
        public string IpAddress { get; set; }
        public string Data { get; set; }
    }
}
