using MediatR;

namespace Udemy.Application.Likes.Command.RemoveLike;

public class RemoveLikeCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; set; } = id;
}
