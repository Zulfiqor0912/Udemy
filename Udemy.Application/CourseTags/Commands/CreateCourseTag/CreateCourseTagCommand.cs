using MediatR;

namespace Udemy.Application.CourseTags.Commands.CreateCourseTag;

public class CreateCourseTagCommand(Guid courseId, Guid tagId) : IRequest
{
    public Guid CourseId { get; } = courseId;
    public Guid TagId { get; } = tagId;
}
