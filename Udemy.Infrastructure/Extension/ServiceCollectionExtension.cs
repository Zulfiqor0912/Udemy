using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UdemyDb");
        services
           .AddDbContext<UdemyDbContext>(options =>
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());
    }
}