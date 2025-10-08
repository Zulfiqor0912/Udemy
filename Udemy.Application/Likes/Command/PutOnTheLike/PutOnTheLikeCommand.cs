using MediatR;

namespace Udemy.Application.Likes.Command.PutOnTheLike;

public class PutOnTheLikeCommand(Guid userId, Guid courseId) : IRequest<bool>
{
    public Guid UserId { get; set; } = userId;
    public Guid CourseId { get; set; } = courseId;
}
