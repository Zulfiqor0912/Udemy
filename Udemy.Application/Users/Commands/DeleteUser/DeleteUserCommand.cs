using MediatR;

namespace Udemy.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}
