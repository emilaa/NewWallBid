using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.ColorModule.Commands.ColoEditCommand;
using WallBid.Business.Modules.ColorModule.Commands.ColorAddCommand;
using WallBid.Business.Modules.ColorModule.Commands.ColorRemoveCommand;
using WallBid.Business.Modules.ColorModule.Queries.ColorGetAllQuery;
using WallBid.Business.Modules.ColorModule.Queries.ColorGetByIdQuery;

namespace WallBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new ColorGetAllRequest());
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] ColorGetByIdRequest request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorAddRequest colorAddRequest)
        {
            await _mediator.Send(colorAddRequest);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> Remove(ColorRemoveRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
