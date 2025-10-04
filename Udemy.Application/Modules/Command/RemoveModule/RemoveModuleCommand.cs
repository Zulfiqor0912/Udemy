using MediatR;

namespace Udemy.Application.Modules.Command.RemoveModule;

public class RemoveModuleCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}
