using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Commands.Login;

public class LoginCommandHandler(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ILogger<LoginCommandHandler> logger,
    IMapper mapper) : IRequestHandler<LoginUserCommand, string>
{
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        try
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null) 
            {
                logger.LogWarning("Login xato: Foydalanuvchi toilmadi", request.Email);
                throw new ApplicationException("Email yoki parol xato");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                logger.LogWarning("Login xato: noto'g'ri parol {Email} ", request.Email);
                throw new ApplicationException("Email yoki parol xato");
            }
            logger.LogInformation("Foydalanuchi muvaffaqqiyatli login qilindi", request.Email);
            //var tokenHandler = new JwtS
        }
        
    }
}
