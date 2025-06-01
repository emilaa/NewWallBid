using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.CarModule.Commands.CarAddCommand;
using WallBid.Business.Modules.SliderModule.Commands.SliderEditCommand;
using WallBid.Business.Modules.SliderModule.Commands.SliderRemoveCommand;
using WallBid.Business.Modules.SliderModule.Queries.SliderGetAllQuery;
using WallBid.Business.Modules.SliderModule.Queries.SliderGetByIdQuery;

namespace WallBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class SliderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SliderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new SliderGetAllRequest());
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] SliderGetByIdRequest request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderAddRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(SliderEditRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Remove(SliderRemoveRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

    }
}
