using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Application.Users.Dtos;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Queries.GetAllUsersByRole;

public class GetAllUsersByRoleQueryHandler(
    ILogger<GetAllUsersByRoleQueryHandler> logger,
    IMapper mapper,
    UserManager<User> userManager,
    RoleManager<IdentityRole<Guid>> roleManager) : IRequestHandler<GetAllUsersByRoleQuery, IEnumerable<UsersByRoleDto>>
{
    public async Task<IEnumerable<UsersByRoleDto>> Handle(GetAllUsersByRoleQuery request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(request.RoleName);
        if (role is null)
        {
            logger.LogInformation("Bunday role topilmadi");
            throw new ArgumentException("Role mos emas", nameof(request.RoleName));
        }

        try
        {
            var users = await userManager.GetUsersInRoleAsync(request.RoleName);
            if (users is null)
            {
                logger.LogInformation("Bu rolga ega foydalanuvchu bazadan topilmadi", nameof(request.RoleName));
                throw new ArgumentException("Bunday foydalanuchilar mavjud emas", nameof(request.RoleName));
            }
            else
            {
                var dto = mapper.Map<IEnumerable<UsersByRoleDto>>(users);
                return dto;
            }
        }
        catch (Exception ex) {
            logger.LogError(ex, "Xatolik yuz berdi");
            throw;
        }
    }
}
