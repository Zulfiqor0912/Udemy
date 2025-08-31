using Microsoft.Extensions.DependencyInjection;
using Udemy.Application.Courses;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Extension;

public static class ServiceCollectionExtension
{
    public static void AddAplication(this IServiceCollection service)
    {
        service.AddScoped<ICourseService, CourseService>();
    }
}
