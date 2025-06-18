using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.BidModule.Commands.BidAddCommand;

namespace WallBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class BidController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BidController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BidAddRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
