using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.ModelModule.Commands.ModelAddCommand;
using WallBid.Business.Modules.ModelModule.Commands.ModelEditCommand;
using WallBid.Business.Modules.ModelModule.Commands.ModelRemoveCommand;
using WallBid.Business.Modules.ModelModule.Queries.ModelGetAllQuery;
using WallBid.Business.Modules.ModelModule.Queries.ModelGetByIdQuery;

namespace WallBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new ModelGetAllRequest());
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] ModelGetByIdRequest request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelAddRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(ModelEditRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> Remove(ModelRemoveRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

    }
}
