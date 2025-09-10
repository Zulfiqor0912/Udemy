using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Users.Commands.Register;

public class RegisterUserCommandHandler(
    ILogger<RegisterUserCommandHandler> logger,
    IMapper mapper,
    IUserRepository userRepository
    ) : IRequestHandler<RegisterUserCommand>
{
    public Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
