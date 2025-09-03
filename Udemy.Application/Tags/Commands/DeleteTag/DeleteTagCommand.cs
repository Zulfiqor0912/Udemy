using MediatR;

namespace Udemy.Application.Tags.Commands.DeleteTag;

public class DeleteTagCommand(string name) : IRequest<bool>
{
    public string Name { get; set; } = name;
}
