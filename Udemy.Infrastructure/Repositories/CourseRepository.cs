using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class CourseRepository(UdemyDbContext dbContext) : ICourseRepository
{
    public async Task CreateCourse(Course course)
    {
        try
        {
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
        } catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            Console.WriteLine($"An error occurred while creating the course: {ex.Message}");
            throw; // Re-throw the exception after logging it
        }
    }

    public async Task DeleteCourse(Course course)
    {
       
        dbContext.Courses.Remove(course);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Course>> GetAllAsyn()
    {
        var course = await dbContext.Courses
            .Include(ct => ct.CourseTags)
                .ThenInclude(t => t.Tag)
            .Include(cb => cb.CreatedBy)
            .ToListAsync();
        return course;
    }

    public async Task<Course?> GetCourseById(Guid id) => await dbContext.Courses
        .Include(ct => ct.CourseTags)
            .ThenInclude(t => t.Tag)
        .Include(cb => cb.CreatedBy)
        .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Course> UpdateCourse(Course course)
    {
        dbContext.Courses.Update(course);
        await dbContext.SaveChangesAsync();
        return course;
    }
}
