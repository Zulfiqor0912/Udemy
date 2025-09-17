using MediatR;
using Udemy.Application.Users.Dtos;

namespace Udemy.Application.Users.Queries.GetAllUsersByRole;

public class GetAllUsersByRoleQuery(string roleName) : IRequest<IEnumerable<UsersByRoleDto>>
{
    public string RoleName { get; set; } = roleName;
}
