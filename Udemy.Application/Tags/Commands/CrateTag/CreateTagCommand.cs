using MediatR;

namespace Udemy.Application.Tags.Commands.CrateTag;

public class CreateTagCommand : IRequest<bool>
{
    public string Name { get; set; } = default!;
}
