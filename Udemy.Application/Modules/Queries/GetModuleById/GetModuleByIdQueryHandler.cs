using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Modules.Queries.GetModuleById;

public class GetModuleByIdQueryHandler(
    ILogger<GetModuleByIdQueryHandler> logger,
    IModuleRepository moduleRepository) : IRequestHandler<GetModuleByIdQuery, Module>
{
    public async Task<Module> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Id ni kiriting");
                throw new ArgumentNullException(nameof(request));
            }
            var module = await moduleRepository.GetModuleById(request.Id);
            return module;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
