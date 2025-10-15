using MediatR;
using Udemy.Application.Comment.Dtos;

namespace Udemy.Application.Comment.Queries.GetCommentForCourse;

public class GetAllCommentForCourseQuery(Guid courseId) : IRequest<IEnumerable<CommentDto>>
{
    public Guid Id { get; set; } = courseId;
}
