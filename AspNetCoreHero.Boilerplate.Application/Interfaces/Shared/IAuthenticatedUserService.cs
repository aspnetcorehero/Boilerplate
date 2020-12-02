using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Shared
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        public string Username { get; }
    }
}
