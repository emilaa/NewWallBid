using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeAddCommand;
using WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeEditCommand;
using WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeRemoveCommand;
using WallBid.Business.Modules.EngineTypeModule.Queries.EngineTypeGetAllQuery;
using WallBid.Business.Modules.EngineTypeModule.Queries.EngineTypeGetByIdQuery;

namespace WallBid.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class EngineTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EngineTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _mediator.Send(new EngineTypeGetAllRequest());
            return Ok(datas);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] EngineTypeGetByIdRequest request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EngineTypeAddRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EngineTypeEditRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Remove(EngineTypeRemoveRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
