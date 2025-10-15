using MediatR;
using Udemy.Application.Comment.Dtos;

namespace Udemy.Application.Comment.Queries.GetCommentForCourse;

internal class GetCommentForCourseQuery(Guid commentId) : IRequest<IEnumerable<CommentDto>>
{
    public Guid Id { get; set; } = commentId;
}
