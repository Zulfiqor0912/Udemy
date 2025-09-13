using MediatR;

namespace Udemy.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    //Foydalanuvchining elektron pochta manzili.
    public string Email { get; set; } = default!;
    //Foydalanuvchiga berilgan role(maqom).
    public string RoleName { get; set; } = default!;
}
