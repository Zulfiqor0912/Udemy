using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Users.Commands.Register;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserManager<User> userManager, SignInManager<User> signInManager) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        throw new NotImplementedException();
    }
}
