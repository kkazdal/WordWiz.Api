using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordWiz.Application.Features.Auth.Commands.Login;
using WordWiz.Application.Features.Auth.Commands.Register;

namespace WordWiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(LoginCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { token });
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<ActionResult<long>> Register(RegisterCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(new { userId });
    }
} 