using MediatR;

namespace Udemy.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest<bool>
{
    public string RoleName { get; set; }
}
