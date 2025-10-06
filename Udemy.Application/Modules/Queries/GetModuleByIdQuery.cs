using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Modules.Queries;

public class GetModuleByIdQuery(Guid id) : IRequest<Module>
{
    public Guid Id { get; set; } = id;
}
