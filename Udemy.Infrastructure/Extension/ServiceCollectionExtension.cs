using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICourseTagRepository, CourseTagRepository>();
        services.AddScoped<IUdemySeeder, UdemySeeder>();
    }
}