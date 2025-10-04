using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Modules.Command.CreateModule;

public class CreateModuleCommandHandler(
    ILogger<CreateModuleCommandHandler> logger,
    IMapper mapper,
    IModuleRepository moduleRepository) : IRequestHandler<CreateModuleCommand, Guid>
{
    public async Task<Guid> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var module = mapper.Map<Module>(request);
            await moduleRepository.CreateModule(module);
            return module.Id;
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Module yaratishda xatolik yuz berrdi");
            throw;
        }
    }
}
