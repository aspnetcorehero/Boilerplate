using AspNetCoreHero.Boilerplate.Application.DTOs;
using AspNetCoreHero.Boilerplate.Application.Features.ActivityLog.Queries.GetUserLogs;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Identity.Pages.Account
{
    public class AuditLogModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _userService;
        public List<AuditLogResponse> AuditLogResponses;
        public AuditLogModel(IMediator mediator, IAuthenticatedUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        public async Task OnGet()
        {
            var response = await _mediator.Send(new GetAuditLogsQuery() { userId = _userService.UserId });
            AuditLogResponses = response.Data;
        }
    }
}
