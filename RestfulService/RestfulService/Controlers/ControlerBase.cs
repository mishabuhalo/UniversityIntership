using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestfulService.Controlers
{
    public class ControlerBase :Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
