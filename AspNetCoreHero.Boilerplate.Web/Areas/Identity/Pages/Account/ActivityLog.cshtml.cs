using AspNetCoreHero.Boilerplate.Application.DTOs;
using AspNetCoreHero.Boilerplate.Application.Features.ActivityLog.Queries.GetUserLogs;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Identity.Pages.Account
{
    public class ActivityLogModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _userService;
        public List<ActivityLogResponse> ActivityLogResponses;
        public ActivityLogModel(IMediator mediator, IAuthenticatedUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        public async Task OnGet()
        {
            var response = await _mediator.Send(new GetUserLogsQuery() { userId = _userService.UserId });
            ActivityLogResponses = response.Data;
        }
    }
}
