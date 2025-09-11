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
            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                logger.LogError("Foydalanuvchi {Email} registratsiyadan o'tmadi: {Errors}", user.Email, errors);
                throw new ApplicationException($"Registratsiya xatosi: {errors}");  
            }
            //await userRepository.AddAsync(user);
            logger.LogInformation("Foydalanuvchi {Email} registratsiyadan muvaffaqqiyatli o'tdi.", user.Email);
            return user.Id;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Kutilmagan xato yuz berdi registratsiya vaqtida: {Email}", user.Email);
            throw;
        }
    }
}
