using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface ICourseRepository
{
    public Task<IEnumerable<Course>> GetAllAsyn();
    public Task CreateCourse(Course course);
    public Task<Course> UpdateCourse(Course course);
    public Task DeleteCourse(Course course);
}
