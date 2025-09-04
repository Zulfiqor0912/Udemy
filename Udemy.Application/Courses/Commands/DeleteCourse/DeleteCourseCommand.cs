using MediatR;

namespace Udemy.Application.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}
