using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Udemy.Domain.Entities;

namespace Udemy.Infrastructure.Authorization;

public class UdemyUserClaimsPrincipalFactory(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options) 
{
    public override Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = GenerateClaimsAsync(user);

        
    }
}
