using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Comment.Command.AddComment;

public class CreateCommentCommand : IRequest
{
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}
