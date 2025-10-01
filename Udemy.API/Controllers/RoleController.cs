using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Roles.Commands.CreateRole;
using Udemy.Application.Roles.Commands.DeleteRole;

namespace Udemy.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]

public class RoleController(
    IMediator mediatR) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        await mediatR.Send(command);
        return Ok(command);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommand command)
    {
        await mediatR.Send(command);
        return Ok(command);
    }
}
