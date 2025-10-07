using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Modules.Queries.GetAllModules;

public class GetAllModulesQueryHandler(
    ILogger<GetAllModulesQueryHandler> logger,
    IModuleRepository moduleRepository) : IRequestHandler<GetAllModulesQuery, IEnumerable<Module>>
{
    public Task<IEnumerable<Module>> Handle(GetAllModulesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var modules = moduleRepository.GetAll();
            if (modules == null)
            {
                logger.LogInformation("Modul mavjud emas!");
                return modules;
            }
            return modules;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
