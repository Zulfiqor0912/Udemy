using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Users.Commands.Register;

public class RegisterUserCommandHandler(
    ILogger<RegisterUserCommandHandler> logger,
    IMapper mapper,
    IUserRepository userRepository,
    UserManager<User> userManager
    ) : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        var user = mapper.Map<User>(request);
        try
        {
            await userRepository.AddAsync(user);
            logger.LogInformation("Foydalanuvchi {Email} registratsiyadan muvaffaqqiyatli o'tdi.", user.Email);
            return user.Id;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Registratsida xato yuz berdi {Email}.", user.Email);
            throw;
        }
    }
}
