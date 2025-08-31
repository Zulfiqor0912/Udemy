using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Courses;

public class CourseService(ICourseRepository courseRepository,
    ILogger<CourseService> logger) : ICourseService
{
    public async Task<IEnumerable<Course>> GetAllCourses()
    {
        logger.LogInformation("Barcha kurslar olindi");
        var result = await courseRepository.GetAllAsyn();
        return result;
    }
}
