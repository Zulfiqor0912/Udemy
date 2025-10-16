using Udemy.Application.Users.Dtos;
using Udemy.Domain.Entities;

namespace Udemy.Application.Comment.Dtos;

public class CommentDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public UserDto UserDto { get; set; }
    public Guid CourseId { get; set; }
}
