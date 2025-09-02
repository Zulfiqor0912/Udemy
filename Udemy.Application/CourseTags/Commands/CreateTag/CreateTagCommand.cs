using MediatR;

namespace Udemy.Application.CourseTags.Commands.CreateTag;

public class CreateTagCommand : IRequest<bool>
{
    public string Name { get; set; } = default!;
}
