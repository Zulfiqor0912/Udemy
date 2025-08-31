using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class CourseRepository(UdemyDbContext dbContext) : ICourseRepository
{
    public async Task<IEnumerable<Course>> GetAllAsyn()
    {
        var courses = await dbContext.Courses.ToListAsync();
        return courses;
    }
}
