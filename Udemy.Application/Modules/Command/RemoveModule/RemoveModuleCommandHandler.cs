using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Modules.Command.RemoveModule;

public class RemoveModuleCommandHandler(
    ILogger<RemoveModuleCommandHandler> logger,
    IModuleRepository moduleRepository) : IRequestHandler<RemoveModuleCommand>
{
    public async Task Handle(RemoveModuleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) 
                logger.LogInformation("Maydonni to'ldiring");
            await moduleRepository.DeleteModule(request.Id);
            logger.LogInformation($"Ushbu module muvaffaqqiyatli O'chirildi: {request.Id}");

        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
