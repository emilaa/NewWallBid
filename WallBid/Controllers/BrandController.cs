using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand;
using WallBid.Business.Modules.BrandModule.Queries.BrandGetAllQuery;

namespace WallBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new BrandGetAllRequest());
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] BrandGetByIdRequest request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandAddRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BrandEditRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Remove(BrandRemoveRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
