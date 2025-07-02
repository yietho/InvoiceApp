using InvoiceApp.Application.Features.Auth.Commands.Login;
using InvoiceApp.Application.Features.Auth.Commands.Register;
using InvoiceApp.Application.Features.Auth.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        await _mediator.Send(new RegisterCommand { User = dto });
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
    {
        var token = await _mediator.Send(new LoginCommand { User = dto });
        return Ok(new { Token = token });
    }
}