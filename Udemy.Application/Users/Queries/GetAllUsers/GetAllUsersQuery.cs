using MediatR;
using Udemy.Application.Users.Dtos;

namespace Udemy.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
}
