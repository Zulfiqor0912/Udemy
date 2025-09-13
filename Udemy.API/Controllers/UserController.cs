using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Users.Commands.Login;
using Udemy.Application.Users.Commands.Register;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediatR) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var userId = await mediatR.Send(command);
        return Ok(new { UserId = userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var token = await mediatR.Send(command);
        return Ok(token);
    }
}
