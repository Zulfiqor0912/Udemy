using Udemy.Domain.Entities;

namespace Udemy.Application.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCourses();
}
