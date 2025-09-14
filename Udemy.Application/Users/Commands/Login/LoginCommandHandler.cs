using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Commands.Login;

public class LoginCommandHandler(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ILogger<LoginCommandHandler> logger,
    IConfiguration config) : IRequestHandler<LoginUserCommand, string>
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
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName ?? user.Email ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim("role", role));
            }

            var secret = config["JWT:Secret"];
            if (string.IsNullOrWhiteSpace(secret))
                throw new Exception("JWT secret topilmadi. Iltimos appsettings yoki user-secrets da sozla.");

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["JWT:Secret"])
            );

            var token = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "");
            throw;
        }
        
    }
}
