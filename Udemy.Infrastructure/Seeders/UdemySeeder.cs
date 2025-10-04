using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Udemy.Application.Users.Commands.Register;
using Udemy.Domain.Constants;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Seeders;

internal class UdemySeeder(
    UdemyDbContext dbContext,
    UserManager<User> userManager,
    RoleManager<IdentityRole<Guid>> roleManager,
    IMapper mapper
    ) : IUdemySeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Tags.Any())
            {
                var tags = GetTags();
                await dbContext.Tags.AddRangeAsync(tags);
                await dbContext.SaveChangesAsync();
            }
        }
        if (!dbContext.Users.Any())
        {
            var registerCommand = GetUser();
            var user = mapper.Map<User>(registerCommand);
            await userManager.CreateAsync(user, "Zulfiqor#1212");
            await userManager.AddToRoleAsync(user, UserRoles.Programmer);
        }

        if (!dbContext.Roles.Any())
        {
            var roles = GetRoles();
            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role.Name)) 
                    await roleManager.CreateAsync(role);          
        }
    }

    private IEnumerable<Tag> GetTags()
    {
        List<Tag> tags = new()
        {
            new Tag {
                Name = ".NET"
            },
            new Tag {
                Name = "Backend"
            },
            new Tag {
                Name = "Frontend"
            },
            new Tag {
                Name = "JavaScript"
            },
            new Tag {
                Name = "TypeScript"
            },
            new Tag {
                Name = "C#"
            },
            new Tag {
                Name = "Java"
            },
            new Tag {
                Name = "Python"
            },
            new Tag {
                Name = "Django"
            },
            new Tag {
                Name = "Flask"
            },
            new Tag {
                Name = "React"
            },
            new Tag {
                Name = "Angular"
            },
            new Tag {
                Name = "Vue"
            },
            new Tag {
                Name = "SQL"
            },
            new Tag {
                Name = "NoSQL"
            },
            new Tag {
                Name = "Database"
            },
            new Tag {
                Name = "HTML"
            },
            new Tag {
                Name = "CSS"
            },
            new Tag {
                Name = "Web Development"
            },
            new Tag {
                Name = "Mobile Development"
            },
            new Tag {
                Name = "DevOps"
            },
            new Tag {
                Name = "Cloud"
            },
            new Tag {
                Name = "AWS"
            },
            new Tag {
                Name = "Azure"
            },
            new Tag {
                Name = "Docker"
            },
            new Tag {
                Name = "Kubernetes"
            },
            new Tag {
                Name = "Machine Learning"
            },
            new Tag {
                Name = "Data Science"
            },
            new Tag {
                Name = "AI"
            },
            new Tag {
                Name = "Cybersecurity"
            },
            new Tag {
                Name = "Networking"
            },
            new Tag {
                Name = "Agile"
            },
            new Tag {
                Name = "Scrum"
            },
            new Tag {
                Name = "Project Management"
            },
            new Tag {
                Name = "UI/UX"
            },
            new Tag {
                Name = "Design Patterns"
            },
            new Tag {
                Name = "Microservices"
            },
            new Tag {
                Name = "RESTful API"
            },
            new Tag {
                Name = "GraphQL"
            },
            new Tag {
                Name = "Testing"
            },
            new Tag {
                Name = "TDD"
            },
            new Tag {
                Name = "BDD"
            },
            new Tag {
                Name = "Version Control"
            },
            new Tag {
                Name = "Git"
            },
            new Tag {
                Name = "CI/CD"
            },
            new Tag {
                Name = "Blockchain"
            },
            new Tag {
                Name = "Game Development"
            },
            new Tag {
                Name = "AR/VR"
            },
            new Tag {
                Name = "IoT"
            },
            new Tag {
                Name = "Big Data"
            },
            new Tag {
                Name = "Java"
            },
            new Tag {
                Name = "Python"
            },
            new Tag {
                Name = "Ruby"
            },
            new Tag {
                Name = "PHP"
            }
        };
        return tags;
    }
    private RegisterUserCommand GetUser()
    {
        var registerUserCommand = new RegisterUserCommand
        {
            FirstName = "Zulfikar",
            LastName = "Rustamov",
            UserName = "zulfiqor_r",
            Email = "zulfiqor@gmail.com",
        };
        return registerUserCommand;
    }

    private IEnumerable<IdentityRole<Guid>> GetRoles()
    {
        List<IdentityRole<Guid>> roles =
            [
                new IdentityRole < Guid >(UserRoles.Programmer),
                new IdentityRole < Guid >(UserRoles.Admin),
                new IdentityRole < Guid >(UserRoles.Teacher),
                new IdentityRole < Guid >(UserRoles.Student),
            ];
        return roles;
    }
    
}
