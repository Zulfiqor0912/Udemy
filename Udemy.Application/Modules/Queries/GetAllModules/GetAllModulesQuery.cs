using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Modules.Queries.GetAllModules;

public class GetAllModulesQuery : IRequest<IEnumerable<Module>>
{
}
