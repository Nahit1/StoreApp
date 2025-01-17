using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
