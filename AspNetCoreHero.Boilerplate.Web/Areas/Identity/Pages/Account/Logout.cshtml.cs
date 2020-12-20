using AspNetCoreHero.Boilerplate.Application.Features.ActivityLog.Commands.AddLog;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using AspNetCoreHero.Boilerplate.Infrastructure.Identity.Models;
using AspNetCoreHero.Boilerplate.Web.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : BasePageModel<LogoutModel>
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IAuthenticatedUserService _userService;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, IMediator mediator, IAuthenticatedUserService userService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _mediator = mediator;
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {

            await _mediator.Send(new AddActivityLogCommand() { userId = _userService.UserId, Action = "Logged Out" });
            await _signInManager.SignOutAsync();
            _notyf.Information("User logged out.");
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
