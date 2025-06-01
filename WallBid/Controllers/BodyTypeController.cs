using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeAddCommand;
using WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeRemoveCommand;
using WallBid.Business.Modules.BodyTypeModule.Queries.BodyTypeGetAllQuery;
using WallBid.Business.Modules.BodyTypeModule.Queries.BodyTypeGetByIdQuery;
using WallBid.Business.Modules.BodyTyperModule.Commands.BodyTypeEditCommand;

namespace WallBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class BodyTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BodyTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new BodyTypeGetAllRequest());
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] BodyTypeGetByIdRequest request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BodyTypeAddRequest colorAddRequest)
        {
            await _mediator.Send(colorAddRequest);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(BodyTypeEditRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> Remove(BodyTypeRemoveRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
