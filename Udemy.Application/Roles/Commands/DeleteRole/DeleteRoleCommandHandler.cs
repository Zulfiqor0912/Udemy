using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Application.Roles.Commands.CreateRole;

namespace Udemy.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler(
    ILogger<DeleteRoleCommandHandler> logger,
    RoleManager<IdentityRole<Guid>> roleManager) : IRequestHandler<DeleteRoleCommand, bool>
{
    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Role XATO");
                return false;
            }


            var role = new IdentityRole<Guid>(request.RoleName);
            var result = await roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                logger.LogWarning("Role o'chirilmadi: {Errors}",
                    string.Join(", ", result.Errors.Select(e => e.Description)));
                return false;
            }

            logger.LogInformation("Role muvaffaqqiyatli o'chirildi!");
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
