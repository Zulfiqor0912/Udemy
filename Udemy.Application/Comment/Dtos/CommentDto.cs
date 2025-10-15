using Udemy.Domain.Entities;

namespace Udemy.Application.Comment.Dtos;

public class CommentDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid CourseId { get; set; }
}
