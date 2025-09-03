using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class CourseRepository(UdemyDbContext dbContext) : ICourseRepository
{
    public async Task CreateCourse(Course course)
    {
        await dbContext.Courses.AddAsync(course);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCourse(Course course)
    {
        dbContext.Courses.Remove(course);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Course>> GetAllAsyn()
    {
        var courses = await dbContext.Courses.ToListAsync();
        return courses;
    }

    public async Task<Course> UpdateCourse(Course course)
    {
        dbContext.Courses.Update(course);
        await dbContext.SaveChangesAsync();
        return course;
    }
}
