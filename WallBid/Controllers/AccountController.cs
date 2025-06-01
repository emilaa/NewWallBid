using MediatR;
using Microsoft.AspNetCore.Mvc;
using WallBid.Business.Modules.AppUserModule.Commands.SignInCommand;
using WallBid.Business.Modules.AppUserModule.Commands.SignUpCommand;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(SignUpRequest command)
    {
        var result = await _mediator.Send(command);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("Registered!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(SignInRequest command)
    {
        var token = await _mediator.Send(command);
        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
}
