using Udemy.Domain.Entities;

namespace Udemy.Application;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCourses();
}
