using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;
using Udemy.Infrastructure.Repositories;
using Udemy.Infrastructure.Seeders;

namespace Udemy.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UdemyDb");
        services
           .AddDbContext<UdemyDbContext>(options =>
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());



        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICourseTagRepository, CourseTagRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUdemySeeder, UdemySeeder>();
    }
}