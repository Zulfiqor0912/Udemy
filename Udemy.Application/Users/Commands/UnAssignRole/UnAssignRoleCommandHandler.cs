using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Commands.UnAssignRole;

public class UnAssignRoleCommandHandler(
     ILogger<UnAssignRoleCommandHandler> logger,
     UserManager<User> userManager,
     RoleManager<IdentityRole<Guid>> roleManager) : IRequestHandler<UnAssignRoleCommand>
{
    public async Task Handle(UnAssignRoleCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            logger.LogError("UnAssignRoleCommandHandler: request is null");
            throw new ArgumentNullException(nameof(request));
        }

        try
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                logger.LogInformation("Bu emaildagi foydalanuvchi topilmadi");
                throw new Exception("Bu emaildagi foydalanuvchi topilmadi");
            }
            var role = await roleManager.FindByNameAsync(request.RoleName);
            if (role is null)
            {
                logger.LogInformation("Bu nomdagi rol topilmadi");
                throw new Exception("Bu nomdagi rol topilmadi");
            }

            var userIsInRole = await userManager.IsInRoleAsync(user, request.RoleName);
            if (userIsInRole)
            {
                await userManager.RemoveFromRoleAsync(user, request.RoleName);
                logger.LogInformation("Foydalanuvchidan rol muvaffaqiyatli o'chirildi");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "UnAssignRoleCommandHandler: Xatolik yuz berdi");
            throw;
        }
    }
}
