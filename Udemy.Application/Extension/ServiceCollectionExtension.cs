using Microsoft.Extensions.DependencyInjection;
using Udemy.Application.Courses;
using Udemy.Application.Services;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Extension;

public static class ServiceCollectionExtension
{
    public static void AddAplication(this IServiceCollection service)
    {
        var assembly = typeof(ServiceCollectionExtension).Assembly;
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        service.AddAutoMapper(assembly);
        service.AddScoped<ICourseService, CourseService>();
    }
}
