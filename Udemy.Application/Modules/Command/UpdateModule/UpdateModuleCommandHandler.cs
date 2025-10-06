using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Modules.Command.UpdateModule;

public class UpdateModuleCommandHandler(
    ILogger<UpdateModuleCommandHandler> logger,
    IMapper mapper,
    IModuleRepository moduleRepository) : IRequestHandler<UpdateModuleCommand>
{
    public async Task Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null) logger.LogError("Maydonlarni to'ldiring");
            var module = mapper.Map<Module>(request);
            await moduleRepository.UpdateModule(request.Id, module);
            logger.LogInformation("Muvaffaqqiyatli yangilandi");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi!");
            throw;
        }
    }
}
