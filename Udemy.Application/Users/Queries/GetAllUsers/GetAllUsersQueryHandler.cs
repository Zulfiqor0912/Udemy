using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Udemy.Application.Users.Dtos;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(
    ILogger<GetAllUsersQueryHandler> logger,
    IMapper mapper,
    UserManager<User> userManager) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await userManager.Users.ToListAsync();
            if (users is null)
            {
                logger.LogInformation("Foydalanuvchilar topilmadi");
                return Enumerable.Empty<UserDto>();
            }
            var allUsers = mapper.Map<IEnumerable<UserDto>>(users);
            return allUsers;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Xatolik yuz berdi");
            throw;
        }
    }
}
