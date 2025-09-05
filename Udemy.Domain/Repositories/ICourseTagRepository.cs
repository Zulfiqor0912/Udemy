using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface ICourseTagRepository
{
    Task AddCourseTag(CourseTag courseTag);
}
