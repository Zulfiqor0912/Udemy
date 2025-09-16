using MediatR;

namespace Udemy.Application.Users.Commands.UnAssignRole;

public class UnAssignRoleCommand : IRequest
{
    public string Email { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
