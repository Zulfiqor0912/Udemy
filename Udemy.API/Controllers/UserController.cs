using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Courses.Queries.GetAll;
using Udemy.Application.Users.Commands.AssignUserRole;
using Udemy.Application.Users.Commands.DeleteUser;
using Udemy.Application.Users.Commands.Login;
using Udemy.Application.Users.Commands.Register;
using Udemy.Application.Users.Commands.UnAssignRole;
using Udemy.Application.Users.Dtos;
using Udemy.Application.Users.Queries.GetAllUsers;
using Udemy.Application.Users.Queries.GetAllUsersByRole;
using Udemy.Domain.Constants;
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

    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediatR.Send(command);
        return Ok();
    }

    [HttpDelete("unassign-role")]
    public async Task<IActionResult> UnAssignUserRole([FromBody] UnAssignRoleCommand command)
    {
        await mediatR.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await mediatR.Send(new DeleteUserCommand(id));
        return NoContent();
    }

    [HttpGet("roles/{roleName}")]
    public async Task<IEnumerable<UsersByRoleDto>> GetAllUsersByRole(string roleName)
    {
        var users = await mediatR.Send(new GetAllUsersByRoleQuery(roleName));
        return users;
    }

    [HttpGet("allUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await mediatR.Send(new GetAllUsersQuery());
        return Ok(users);
    }
}
