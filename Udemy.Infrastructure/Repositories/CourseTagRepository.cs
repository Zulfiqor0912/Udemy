using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class CourseTagRepository(UdemyDbContext dbContext) : ICourseTagRepository
{
    public async Task AddCourseTag(CourseTag courseTag)
    {
        await dbContext.CourseTags.AddAsync(courseTag);
        await dbContext.SaveChangesAsync();
    }
}
