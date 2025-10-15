using MediatR;

namespace Udemy.Application.Comment.Command.DeleteComment;

public class DeleteCommentCommand(Guid commentId) : IRequest
{
    public Guid CommentId { get; set; } = commentId;
}
