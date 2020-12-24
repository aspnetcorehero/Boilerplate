using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreHero.Boilerplate.Web.Abstractions
{
    public class BasePageModel<T> : PageModel where T : class
    {
        private IMediator _mediator;

        //private IMapper _mapper;
        private ILogger<T> _logger;

        //private IViewRenderService _viewRenderService;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();

        //protected IViewRenderService Renderer => _viewRenderService ??= HttpContext.RequestServices.GetService<IViewRenderService>();
        private INotyfService notyf;

        protected INotyfService _notyf => notyf ??= HttpContext.RequestServices.GetService<INotyfService>();
    }
}