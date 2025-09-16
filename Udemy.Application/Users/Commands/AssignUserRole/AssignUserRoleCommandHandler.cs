using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(
    ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole<Guid>> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            logger.LogInformation("Email yoki role null");
            throw new ArgumentNullException(nameof(request));
        }
        try
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                logger.LogInformation("Bunday foydalanuvchi topilmadi");
                throw new ArgumentNullException(nameof(user));
            }
            var role = await roleManager.FindByNameAsync(request.RoleName);
            if (role is null)
            {
                logger.LogInformation("Bunday role topilmadi");
                throw new ArgumentNullException(nameof(role));
            }
            var isInRole = await userManager.IsInRoleAsync(user, request.RoleName);
            if (isInRole) throw new Exception("Foydalanuvchi allaqachon ushbu rolda");
            else
            {
                await userManager.AddToRoleAsync(user, request.RoleName);

            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Xatolik yuz berdi!");
            throw;
        }
        
    }
}
