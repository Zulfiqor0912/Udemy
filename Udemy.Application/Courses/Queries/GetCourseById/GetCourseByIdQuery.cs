using MediatR;
using Udemy.Application.Courses.Dtos;

namespace Udemy.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQuery(Guid id) : IRequest<CourseDto>
{
    public Guid Id { get; set; } = id;
}
