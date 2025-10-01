using MediatR;

namespace Udemy.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<bool>
{
   public string RoleName { get; set; }
}
