using MediatR;
using Udemy.Application.Comment.Dtos;

namespace Udemy.Application.Comment.Queries.GetAllCommentsByUserForCourse;

internal class GetAllCommentsByUserForCourseQuery(Guid courseId, Guid userId) : IRequest<IEnumerable<CommentDto>>
{
    public Guid CourseId { get; set; } = courseId;
    public Guid UserId { get; set; } = userId;
}
