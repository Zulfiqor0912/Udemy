using MediatR;
using Udemy.Application.Comment.Dtos;

namespace Udemy.Application.Comment.Queries.GetCommentForCourse;

public class GetCommentForCourseQuery(Guid commentId) : IRequest<CommentDto>
{
    public Guid Id { get; set; } = commentId;
}
