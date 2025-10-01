using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Udemy.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler(
    ILogger<CreateRoleCommandHandler> logger,
    IMapper mapper,
    RoleManager<IdentityRole<Guid>> roleManager) : IRequestHandler<CreateRoleCommand, bool>
{
    public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Role XATO");
                return false;
            }


            var role = new IdentityRole<Guid>(request.RoleName);
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                logger.LogWarning("Role yaratilmadi: {Errors}",
                    string.Join(", ", result.Errors.Select(e => e.Description)));
                return false;
            }

            logger.LogInformation("Yangi Role qo‘shildi: {RoleName}", request.RoleName);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex,"Nimadir xato ketdi");
            throw;
        }
    }
}
