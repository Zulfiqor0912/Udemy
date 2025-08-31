using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface ICourseRepository
{
    public Task<IEnumerable<Course>> GetAllAsyn();
}
