using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Udemy.Application.Modules.Command.CreateModule;

public class CreateModuleCommandHandler(
    ILogger<CreateModuleCommandHandler> logger,
    IMapper mapper,
    IModule) : IRequestHandler<CreateModuleCommand, Guid>
{
    public Task<Guid> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
    {
        
    }
}
