using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Comment.Command.UpdateComment;

public class UpdateCommentCommand(Guid commentId) : IRequest
{
    public Guid Id { get; set; } = commentId;
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}
