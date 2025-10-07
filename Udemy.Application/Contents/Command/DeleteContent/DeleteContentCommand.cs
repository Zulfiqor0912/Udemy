using MediatR;

namespace Udemy.Application.Contents.Command.DeleteContent;

public class DeleteContentCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}
