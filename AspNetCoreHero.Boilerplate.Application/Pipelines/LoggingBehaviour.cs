using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Pipelines
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public LoggingBehaviour(
            ILogger<TRequest> logger,
            IAuthenticatedUserService authenticatedUserService
            )
        {
            _logger = logger;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            try
            {
                _logger.LogInformation("{Name} Request From User {UserId}-{UserName}", requestName, _authenticatedUserService.UserId, _authenticatedUserService.Username);
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Name} Request Exception Message : {Error} From User {UserId}-{UserName}", requestName,ex.Message,_authenticatedUserService.UserId,_authenticatedUserService.Username);
                throw;
            }
        }
    }
}
